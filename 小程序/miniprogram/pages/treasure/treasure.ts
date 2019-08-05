//logs.js

Page({
  data: {

  },
  onLoad() {
    let x: any = {
      url: "http://39.105.206.6:8080/api/Treasure/GetRecordCount",
      method: "GET",
      success(res: any) {
        this.suc(res);
      },
      fail(fail: any) {
        this.fail(fail);
      }
    };
    wx.request(x);
  },
  suc(res: any) {
    console.log(res.any)
  }
})
