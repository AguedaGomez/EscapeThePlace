//
//  NearbyMessagesScanner.m
//  iOSUNM
//
//  Created by Alberto Gonzalez Perez on 07/05/2019.
//

#import "NearbyMessagesScanner.h"
#import "ConfigProvider.h"
#import "INearbyMessagesCallback.h"
#import "GNSMessages.h"
#import "NearbyMessage.h"

static NSString* bluetoothDisabledError = @"BLUETOOTH_DISABLED";
static NSString* noBluetoothPermissionError = @"NO_BLUETOOTH_PERMISSION";

@implementation NearbyMessagesScanner {
    ConfigProvider* _configProvider;
    id<INearbyMessagesCallback> _callback;
    
    GNSMessageManager* _messageManager;
    id<GNSSubscription> _subscription;
}
@synthesize callback = _callback;

- (instancetype) initWithConfiguration:(ConfigProvider*) configProvider
                              callback:(id<INearbyMessagesCallback>) callback {
    self = [super init];
    if (self) {
        _configProvider = configProvider;
        _callback = callback;
    }
    return self;
}

- (void) startScan {
    [self initailize];
    [self changeNerbyPermission:true];
    
    __weak __typeof__(self) weakSelf = self;
    
    NSLog(@"Creating subscription");
    _subscription = [_messageManager subscriptionWithMessageFoundHandler:^(GNSMessage* message) {
        NearbyMessage* nearbyMessage = [self nearbyMessageFrom:message];
        NSLog(@"Message received: %@", [nearbyMessage content]);
        [weakSelf.callback onMessageFound:nearbyMessage];
    } messageLostHandler:^(GNSMessage* message) {
        NearbyMessage* nearbyMessage = [self nearbyMessageFrom:message];
        NSLog(@"Message lost: %@", [nearbyMessage content]);
        [weakSelf.callback onMessageLost:nearbyMessage];
    } paramsBlock:^(GNSSubscriptionParams *params) {
        // Scan beacons only
        params.deviceTypesToDiscover = kGNSDeviceBLEBeacon;
        
        // Do not broadcast and use bluetooth only, also run in background (always needed for unity)
        params.strategy = [GNSStrategy strategyWithParamsBlock:^(GNSStrategyParams *params) {
            params.discoveryMediums = kGNSDiscoveryMediumsBLE;
            params.discoveryMode = kGNSDiscoveryModeScan;
        }];
    }];
}

- (void) stopScan {
    [self changeNerbyPermission:false];
    _subscription = nil;
}

- (void) initailize {
    if (_messageManager != nil) return;
    __weak __typeof__(self) weakSelf = self;
    
    _messageManager = [[GNSMessageManager alloc]
                       initWithAPIKey:[_configProvider apiKey]
                       paramsBlock:^(GNSMessageManagerParams* params) {
                           params.bluetoothPowerErrorHandler = ^(BOOL hasError) {
                               NSLog(@"Bluetooth is turned of!");
                               [weakSelf.callback onFailure:bluetoothDisabledError];
                           };
                           params.bluetoothPermissionErrorHandler = ^(BOOL hasError) {
                               NSLog(@"Bluetooth permission missing!");
                               [weakSelf.callback onFailure:noBluetoothPermissionError];
                           };
    }];
}

- (void) changeNerbyPermission:(BOOL) granted {
    [GNSPermission setGranted:granted];
}

- (NearbyMessage*) nearbyMessageFrom:(GNSMessage*) message {
    return [[NearbyMessage alloc] initWithContent:[[NSString alloc] initWithData:[message content] encoding:NSUTF8StringEncoding]
                                           nspace:[message messageNamespace]
                                             type:[message type]];
}

@end
