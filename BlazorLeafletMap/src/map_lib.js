import L from 'leaflet';

export function initializeMap(options) {
    const map = L.map('map').setView([44.0542, 15.2989], 13);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);
}