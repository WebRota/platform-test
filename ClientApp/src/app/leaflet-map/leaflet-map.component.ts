import { Component, OnInit } from '@angular/core';
import * as L from 'leaflet';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-leaflet-map',
  templateUrl: './leaflet-map.component.html',
  styleUrls: ['./leaflet-map.component.css']
})
export class LeafletMapComponent implements OnInit {
  totalDistance: number = 0;
  map!: L.Map;
  markers: L.Marker[] = []; // Usando o tipo Marker
  polyline: L.Polyline | null = null;
  message: string = "Clique no mapa para adicionar novas coordenadas.";
  showMessage: boolean = false;

  
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.map = L.map('map').setView([-18.924067, -48.282142], 12);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(this.map);

    this.polyline = L.polyline([], { color: 'blue' }).addTo(this.map);

    this.http.get('./assets/positions.json').subscribe((data: any) => {
      const positionsData = data;
      const positions = positionsData.data;

      positions.forEach((position: any) => {
        const lat = parseFloat(position.latitude);
        const lon = parseFloat(position.longitude);
        this.addMarker(lat, lon);
      });

      this.map.fitBounds(L.featureGroup(this.markers).getBounds());
    });
  }

 
  // Adicione esta variável à sua classe LeafletMapComponent
  clickedPoint: L.LatLng | null = null;
  addMarkerFromClick() {
    this.showMessage = true;
    // Solicite ao usuário que clique no mapa para adicionar um novo marcador
    this.map.on('click', (e: L.LeafletMouseEvent) => {
      const marker = L.marker(e.latlng).addTo(this.map);
      this.markers.push(marker);
      if (this.markers.length > 1) {
        const prevMarker = this.markers[this.markers.length - 2];
        const currentMarker = this.markers[this.markers.length - 1];

        const distance = prevMarker.getLatLng().distanceTo(currentMarker.getLatLng());
        this.totalDistance += distance;

        if (this.polyline) {
          this.polyline.addLatLng(currentMarker.getLatLng());
        }
      }
    });
  }
  addMarker(lat: number, lon: number) {
    const marker = L.marker([lat, lon]).addTo(this.map);
    this.markers.push(marker);

    if (this.markers.length > 1) {
      const prevMarker = this.markers[this.markers.length - 2];
      const currentMarker = this.markers[this.markers.length - 1];

      const distance = prevMarker.getLatLng().distanceTo(currentMarker.getLatLng());
      this.totalDistance += distance;

      if (this.polyline) {
        this.polyline.addLatLng(currentMarker.getLatLng());
      }
    }
  }
}
