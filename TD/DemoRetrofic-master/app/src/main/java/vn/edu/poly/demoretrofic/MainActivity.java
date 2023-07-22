package vn.edu.poly.demoretrofic;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.RecyclerView;

import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import java.sql.Array;
import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class MainActivity extends AppCompatActivity {
    RecyclerView rcvLisst;
    List<Account> listacc = new ArrayList<>();
    Adapter adapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        GetListAcc();
        rcvLisst = findViewById(R.id.rcv_list);
    }

    @Override
    protected void onStart() {
        super.onStart();
        GetListAcc();
    }

    @Override
    protected void onResume() {
        super.onResume();
        GetListAcc();
    }

    void GetAccount() {
        ApiService.apiService.getAccpunt("admin", "123").enqueue(new Callback<List<Account>>() {
            @Override
            public void onResponse(Call<List<Account>> call, Response<List<Account>> response) {
                List<Account> listAcc = response.body();
                if (listAcc != null) {

                }
            }

            @Override
            public void onFailure(Call<List<Account>> call, Throwable t) {
                Toast.makeText(MainActivity.this, "Lỗi", Toast.LENGTH_SHORT).show();
            }
        });
    }

    public void GetListAcc() {
        ApiService.apiService.getListAcc().enqueue(new Callback<List<Account>>() {
            @Override
            public void onResponse(Call<List<Account>> call, Response<List<Account>> response) {
                    if (response.body() != null) {
                        listacc= response.body();
                        adapter = new Adapter(listacc);
                        rcvLisst.setAdapter(adapter);
                    }

                Log.d("zzzzzzzz", "onResponse: " + listacc.size());
            }

            @Override
            public void onFailure(Call<List<Account>> call, Throwable t) {
                Toast.makeText(MainActivity.this, "Lỗi", Toast.LENGTH_SHORT).show();
            }
        });

    }
}