//
//  NearbyMessage.h
//  iOSUNM
//
//  Created by Alberto Gonzalez Perez on 07/05/2019.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface NearbyMessage : NSObject
@property(readonly) NSString* content;
@property(readonly) NSString* nspace;
@property(readonly) NSString* type;

- (instancetype) initWithContent:(NSString*) content
                          nspace: (NSString*) nspace
                            type:(NSString*) type;

@end

NS_ASSUME_NONNULL_END
