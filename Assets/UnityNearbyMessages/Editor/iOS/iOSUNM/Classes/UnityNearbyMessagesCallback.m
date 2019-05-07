//
//  UnityNearbyMessagesCallback.m
//  iOSUNM
//
//  Created by Alberto Gonzalez Perez on 07/05/2019.
//

#import "UnityNearbyMessagesCallback.h"
#import "NearbyMessage.h"
#import "IUnityInterface.h"

static const char * unityReceiverObject = "NearbyMessagesEventSystem";

static const char * messageFoundReceiver = "MessageFound";
static const char * messageLostReceiver = "MessageLost";
static const char * failureReceiver = "ProviderFailure";

static NSString* delimiter = @"<[]>";


@implementation UnityNearbyMessagesCallback

- (void) onMessageFound:(NearbyMessage*) message {
    NSString* encodedMessage = [self encodeMessage:message];
    UnitySendMessage(unityReceiverObject, messageFoundReceiver,
                     [encodedMessage cStringUsingEncoding:NSUTF8StringEncoding]);
}

- (void) onMessageLost:(NearbyMessage*) message {
    NSString* encodedMessage = [self encodeMessage:message];
    UnitySendMessage(unityReceiverObject, messageLostReceiver,
                     [encodedMessage cStringUsingEncoding:NSUTF8StringEncoding]);
}

- (void) onFailure:(NSString*) error {
    UnitySendMessage(unityReceiverObject, failureReceiver,
                     [error cStringUsingEncoding:NSUTF8StringEncoding]);
}

- (NSString*) encodeMessage:(NearbyMessage*) message {
    return [NSString stringWithFormat:@"%@%@%@%@%@",
            [message content], delimiter, [message nspace], delimiter, [message type]];
}

@end
