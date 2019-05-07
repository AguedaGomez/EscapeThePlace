//
//  NearbyMessage.m
//  iOSUNM
//
//  Created by Alberto Gonzalez Perez on 07/05/2019.
//

#import "NearbyMessage.h"

@implementation NearbyMessage {
    NSString* _content;
    NSString* _nspace;
    NSString* _type;
}
@synthesize content = _content;
@synthesize nspace = _nspace;
@synthesize type = _type;

- (instancetype) initWithContent:(NSString *)content
                          nspace:(NSString *)nspace
                            type:(NSString *)type {
    self = [super init];
    if (self) {
        _content = content;
        _nspace = nspace;
        _type = type;
    }
    return self;
}

@end
