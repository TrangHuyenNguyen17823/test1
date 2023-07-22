package vn.edu.poly.demoretrofic;

import android.content.Context;
import android.net.Uri;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.util.ArrayList;
import java.util.List;

public class Adapter extends RecyclerView.Adapter<Adapter.ViewHoderIem> {
    List<Account> listPro;
    Context context;
    String TAG="zzzzzzzzzzzz";

    public Adapter(List<Account> listPro) {
        this.listPro = listPro;
    }

    @NonNull
    @Override
    public ViewHoderIem onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        LayoutInflater layoutInflater = LayoutInflater.from(parent.getContext());
        View view = layoutInflater.inflate(R.layout.item_propduct, parent, false);
        context = parent.getContext();
        Log.d(TAG, "onBindViewHolder:create list size"+listPro.size());
        return new ViewHoderIem(view);
    }

    @Override
    public void onBindViewHolder(@NonNull ViewHoderIem holder, int position) {
        final  int index = position;
        Log.d(TAG, "onBindViewHolder: list size"+listPro.size());
       holder.tvName.setText(listPro.get(index).getUserName());
       holder.tvPrice.setText(listPro.get(index).getPassWd());
       holder.imgAvate.setImageURI(Uri.parse(listPro.get(index).getImg()));
    }

    @Override
    public int getItemCount() {
        Log.d(TAG, "getItem: list size"+listPro.size());
        return listPro==null?0: listPro.size();
    }

    public class  ViewHoderIem extends RecyclerView.ViewHolder{
        public ImageView imgAvate;
        public TextView tvName;
        public TextView tvPrice;
        public ViewHoderIem(@NonNull View itemView) {
            super(itemView);
            imgAvate = itemView.findViewById(R.id.img_avate);
            tvName = itemView.findViewById(R.id.tv_name);
            tvPrice = itemView.findViewById(R.id.tv_price);

        }
    }
}
