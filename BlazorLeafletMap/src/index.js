import { getCurrentTime } from './time_lib';
import { initializeMap, drawPoint } from "./map_lib";

export function InitializeMap(options) {
    return initializeMap(options);
}

export function DrawPoint(map, options) {
    return drawPoint(map, options);
}