//
//  INearbyMessagesCallback.h
//  iOSUNM
//
//  Created by Alberto Gonzalez Perez on 07/05/2019.
//

#ifndef INearbyMessagesCallback_h
#define INearbyMessagesCallback_h

#import <Foundation/Foundation.h>
#import "NearbyMessage.h"

@protocol INearbyMessagesCallback<NSObject>
- (void) onMessageFound:(NearbyMessage*) message;
- (void) onMessageLost:(NearbyMessage*) message;
- (void) onFailure:(NSString*) error;
@end

#endif /* INearbyMessagesCallback_h */
