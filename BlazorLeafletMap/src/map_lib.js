import L from 'leaflet';

export function initializeMap({latitude, longitude, zoomLevel}) {
    const map = L.map('map').setView([latitude, longitude], zoomLevel);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);

    return map;
}

export function drawPoint(map, { latitude, longitude, radius, tooltipText }) {
    var yachtMarker = L.circle([latitude, longitude], { radius }).addTo(map);

    yachtMarker.bindTooltip(`${(tooltipText ? `${tooltipText}: `:"")}${latitude}, ${longitude}`);

    console.log(map);
    console.log(yachtMarker);
    return yachtMarker;
}