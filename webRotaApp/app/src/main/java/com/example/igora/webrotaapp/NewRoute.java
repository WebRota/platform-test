package com.example.igora.webrotaapp;

import android.graphics.Color;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.MapFragment;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.MarkerOptions;
import com.google.android.gms.maps.model.Polyline;
import com.google.android.gms.maps.model.PolylineOptions;

public class NewRoute extends AppCompatActivity implements OnMapReadyCallback, TaskLoadedCallback {


    GoogleMap map;
    Button btnGetDirection;
    MarkerOptions place1;
    MarkerOptions place2;
    MarkerOptions place3;
    MarkerOptions place4;
    MarkerOptions place5;
    MarkerOptions place6;
    MarkerOptions place7;
    MarkerOptions place8;
    MarkerOptions place9;
    MarkerOptions place10;
    MarkerOptions place11;
    MarkerOptions place12;
    MarkerOptions place13;
    MarkerOptions place14;
    MarkerOptions place15;
    MarkerOptions place16;
    Polyline currentPolyline;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_new_route);

        btnGetDirection = findViewById(R.id.btnGetDirection);
        MapFragment mapFragment = (MapFragment) getFragmentManager().findFragmentById(R.id.map_frag);
        mapFragment.getMapAsync(this);

        place1 = new MarkerOptions().position(new LatLng(-18.92406700, -48.28214200)).title("Location 1");
        place2 = new MarkerOptions().position(new LatLng(-18.92376500, -48.28210800)).title("Location 2");
        place3 = new MarkerOptions().position(new LatLng(-18.92213500, -48.28205200)).title("Location 3");
        place4 = new MarkerOptions().position(new LatLng(-18.92082200, -48.28132800)).title("Location 3");
        place5 = new MarkerOptions().position(new LatLng(-18.91951300, -48.28033200)).title("Location 3");
        place6 = new MarkerOptions().position(new LatLng(-18.91966300, -48.27849800)).title("Location 3");
        place7 = new MarkerOptions().position(new LatLng(-18.92081800, -48.27682200)).title("Location 1");
        place8 = new MarkerOptions().position(new LatLng(-18.92195000, -48.27513200)).title("Location 2");
        place9 = new MarkerOptions().position(new LatLng(-18.92298100, -48.27350800)).title("Location 3");
        place10 = new MarkerOptions().position(new LatLng(-18.92313700, -48.27337200)).title("Location 3");
        place11 = new MarkerOptions().position(new LatLng(-18.92372200, -48.27213800)).title("Location 3");
        place12 = new MarkerOptions().position(new LatLng(-18.92295000, -48.27078200)).title("Location 3");
        place13 = new MarkerOptions().position(new LatLng(-18.91990800, -48.26785500)).title("Location 1");
        place14 = new MarkerOptions().position(new LatLng(-18.91765300, -48.26528000)).title("Location 2");
        place15 = new MarkerOptions().position(new LatLng(-18.91815100, -48.26453900)).title("Location 3");
        place16 = new MarkerOptions().position(new LatLng(-18.91814500, -48.26453700)).title("Location 3");


        btnGetDirection.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                new FetchURL(NewRoute.this).execute(getUrl(place1.getPosition(), place2.getPosition(), place3.getPosition(),
                        place4.getPosition(), place5.getPosition(), place6.getPosition(),
                        place7.getPosition(), place8.getPosition(), place9.getPosition(),
                        place10.getPosition(), place11.getPosition(), place12.getPosition(),
                        place11.getPosition(), place12.getPosition(), place13.getPosition(),
                        place14.getPosition(),"driving "), "driving");
            }
        });


    }

    private String getUrl(LatLng origin, LatLng dest, LatLng dest1,
                          LatLng dest2, LatLng dest3, LatLng dest4 ,
                          LatLng dest5, LatLng dest6, LatLng dest7,
                          LatLng dest8, LatLng dest9, LatLng dest10,
                          LatLng dest11, LatLng dest12, LatLng dest13,
                          LatLng dest14, String directionMode) {
        // Origin of route
        String str_origin = "origin=" + origin.latitude + "," + origin.longitude;
        // Destination of route
        String str_dest = "destination=" + dest.latitude + "," + dest.longitude;

        String str_dest1 = "destination=" + dest1.latitude + "," + dest1.longitude;
        // Mode
        String str_dest2 = "destination" + dest2.latitude + "," + dest2.longitude;

        String str_dest3 = "origin=" + dest3.latitude + "," + dest3.longitude;
        // Destination of route
        String str_dest4 = "destination=" + dest4.latitude + "," + dest4.longitude;

        String str_dest5 = "destination=" + dest5.latitude + "," + dest5.longitude;
        // Mode
        String str_dest6 = "destination" + dest6.latitude + "," + dest6.longitude;

        String str_dest7 = "origin=" + dest7.latitude + "," + dest7.longitude;
        // Destination of route
        String str_dest8 = "destination=" + dest8.latitude + "," + dest8.longitude;

        String str_dest9 = "destination=" + dest9.latitude + "," + dest9.longitude;
        // Mode
        String str_dest10 = "destination" + dest10.latitude + "," + dest10.longitude;

        String str_dest11 = "origin=" + dest11.latitude + "," + dest11.longitude;
        // Destination of route
        String str_dest12 = "destination=" + dest12.latitude + "," + dest12.longitude;

        String str_dest13 = "destination=" + dest13.latitude + "," + dest13.longitude;
        // Mode
        String str_dest14 = "destination" + dest14.latitude + "," + dest14.longitude;

        String mode = "mode=" + directionMode;
        // Building the parameters to the web service
        String parameters = str_origin + "&" + str_dest + "&" + str_dest1 + "&" +
                str_dest2 + "&" + str_dest3 + "&" + str_dest4 + "&" +
                str_dest5 + "&" + str_dest6 + "&" + str_dest7 + "&" +
                str_dest8 + "&" + str_dest9 + "&" + str_dest10 + "&" +
                str_dest11 + "&" + str_dest12 + "&" + str_dest13 + "&" +
                str_dest14 + "&" +
                mode;
        // Output format
        String output = "json";
        // Building the url to the web service
        String url = "https://maps.googleapis.com/maps/api/directions/" + output + "?" + parameters + "&key=" + getString(R.string.google_maps_key);
        return url;
    }

    @Override
    public void onMapReady(GoogleMap googleMap) {
        map = googleMap;
        map.addMarker(place1);
        map.addMarker(place2);
        map.addMarker(place3);
        map.addMarker(place4);
        map.addMarker(place5);
        map.addMarker(place6);
        map.addMarker(place7);
        map.addMarker(place8);
        map.addMarker(place9);
        map.addMarker(place10);
        map.addMarker(place11);
        map.addMarker(place12);
        map.addMarker(place13);
        map.addMarker(place14);
        map.addMarker(place15);
    }

    @Override
    public void onTaskDone(Object... values) {
        if (currentPolyline!=null)
            currentPolyline.remove();
        map.addPolyline((PolylineOptions) values[0]).setColor(Color.BLUE);
    }
}
