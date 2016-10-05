#import <Foundation/Foundation.h>

void enableBatteryMonitoring() {
    [UIDevice currentDevice].batteryMonitoringEnabled = YES;
}

void disableBatteryMonitoring() {
    [UIDevice currentDevice].batteryMonitoringEnabled = NO;
}

float getBatteryLevel() {
    float batteryLevel = [UIDevice currentDevice].batteryLevel;
    
    return batteryLevel;
}
