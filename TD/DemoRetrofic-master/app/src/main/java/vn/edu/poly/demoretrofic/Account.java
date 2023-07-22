package vn.edu.poly.demoretrofic;

import com.google.gson.annotations.SerializedName;

public class Account {
    @SerializedName("id")
    private String id;
    @SerializedName("username")
    private String userName;
    @SerializedName("image")
    private String img;
    @SerializedName("password")
    private String passWd;

    public Account() {
    }

    public Account(String id, String userName, String img, String passWd) {
        this.id = id;
        this.userName = userName;
        this.img = img;
        this.passWd = passWd;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getUserName() {
        return userName;
    }

    public void setUserName(String userName) {
        this.userName = userName;
    }

    public String getImg() {
        return img;
    }

    public void setImg(String img) {
        this.img = img;
    }

    public String getPassWd() {
        return passWd;
    }

    public void setPassWd(String passWd) {
        this.passWd = passWd;
    }
}
