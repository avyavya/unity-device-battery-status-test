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

int getBatteryStatus() {
    int state;
        
    switch ([UIDevice currentDevice].batteryState)
    {
        case UIDeviceBatteryStateFull:
            state = 2;
            break;
            
        case UIDeviceBatteryStateCharging:
            state = 1;
            break;
            
        case UIDeviceBatteryStateUnplugged:
            state = 0;
            break;
            
        default:
        case UIDeviceBatteryStateUnknown:
            state = -1;
            break;
    }
    
    return state;
}

