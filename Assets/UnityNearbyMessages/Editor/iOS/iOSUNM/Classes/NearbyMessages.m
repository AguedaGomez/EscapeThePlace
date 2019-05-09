//
//  NearbyMessages.m
//  iOSUNM
//
//  Created by Alberto Gonzalez Perez on 06/05/2019.
//

#import "NearbyMessages.h"
#import "ConfigProvider.h"
#import "INearbyMessagesCallback.h"
#import "UnityNearbyMessagesCallback.h"
#import "NearbyMessagesScanner.h"

@implementation NearbyMessages {
    ConfigProvider* _configProvider;
    id<INearbyMessagesCallback> _callback;
    NearbyMessagesScanner* _messagesScanner;
}

- (instancetype) init {
    self = [super init];
    if (self) {
        _configProvider = [[ConfigProvider alloc] init];
        _callback = [[UnityNearbyMessagesCallback alloc] init];
        _messagesScanner = [[NearbyMessagesScanner alloc] initWithConfiguration:_configProvider
                                                                       callback:_callback];
    }
    return self;
}

- (void) initialize:(NSString*) appKey {
    [_configProvider setApiKey:appKey];
    NSLog(@"NearbyMessages initialized. API key: %@", [_configProvider apiKey]);
}

- (void) startScan {
    [_messagesScanner startScan];
}

- (void) stopScan {
    [_messagesScanner stopScan];
}

@end
