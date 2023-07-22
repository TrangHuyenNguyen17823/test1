package vn.edu.poly.demoretrofic;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.internal.GsonBuildConfig;

import java.util.List;

import retrofit2.Call;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;
import retrofit2.http.GET;
import retrofit2.http.Query;

public interface ApiService {
        // khởi tạo Gson
        Gson gson = new GsonBuilder()
                .setDateFormat("yyyy-MM-dd HH:mm:ss")
                .create();
        // khởi tạo retrofit
        ApiService apiService = new Retrofit.Builder()
                // là dumain cảu api
                .baseUrl("http://192.168.1.169:3000/")
                .addConverterFactory(GsonConverterFactory.create(gson))
                .build(). create(ApiService.class);

        // định dạng kiểu Call Api
        @GET("account")
        Call<List<Account>> getAccpunt (@Query("username") String username,
                               @Query("password") String password);
        @GET("account")
        Call<List<Account>> getListAcc();
        // @Path là để truyền tham số động vào @GET("account/{tham số động}"), @PUT("account/{tham số động}"), @DELETE("account/{tham số động}")
        // @Body dùng để Post 1 objetct lên server dạng json

}
