//
//  NearbyMessages.h
//  iOSUNM
//
//  Created by Alberto Gonzalez Perez on 06/05/2019.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface NearbyMessages : NSObject
- (void) initialize:(NSString*) appKey;
- (void) startScan;
- (void) stopScan;
@end

NS_ASSUME_NONNULL_END
