//
//  NearbyMessagesScanner.h
//  iOSUNM
//
//  Created by Alberto Gonzalez Perez on 07/05/2019.
//

#import <Foundation/Foundation.h>
#import "ConfigProvider.h"
#import "INearbyMessagesCallback.h"

NS_ASSUME_NONNULL_BEGIN

@interface NearbyMessagesScanner : NSObject
@property(readonly) id<INearbyMessagesCallback> callback;

- (instancetype) initWithConfiguration:(ConfigProvider*) configProvider
                              callback:(id<INearbyMessagesCallback>) callback;
- (void) startScan;
- (void) stopScan;
@end

NS_ASSUME_NONNULL_END
