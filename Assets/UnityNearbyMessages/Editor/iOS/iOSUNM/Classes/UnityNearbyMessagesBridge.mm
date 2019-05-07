//
//  NearbyMessagesBridge.m
//  iOSUNM
//
//  Created by Alberto Gonzalez Perez on 05/05/2019.
//

#import "NearbyMessages.h"

static NearbyMessages* nearbyMessages = [[NearbyMessages alloc] init];

#pragma mark - C interface

extern "C" {
    
    void _unm_initialize(const char * apiKey) {
        [nearbyMessages initialize:[NSString stringWithCString:apiKey encoding:NSUTF8StringEncoding]];
    }
    
    void _unm_startScan() {
        [nearbyMessages startScan];
    }
    
    void _unm_stopScan() {
        [nearbyMessages stopScan];
    }
    
}
