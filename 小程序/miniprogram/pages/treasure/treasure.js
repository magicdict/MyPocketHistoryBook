"use strict";
Page({
    data: {},
    onLoad: function () {
        var x = {
            url: "http://39.105.206.6:8080/api/Treasure/GetRecordCount",
            method: "GET",
            success: function (res) {
                this.suc(res);
            },
            fail: function (fail) {
                this.fail(fail);
            }
        };
        wx.request(x);
    },
    suc: function (res) {
        console.log(res.any);
    }
});
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoidHJlYXN1cmUuanMiLCJzb3VyY2VSb290IjoiIiwic291cmNlcyI6WyJ0cmVhc3VyZS50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiO0FBRUEsSUFBSSxDQUFDO0lBQ0gsSUFBSSxFQUFFLEVBRUw7SUFDRCxNQUFNO1FBQ0osSUFBSSxDQUFDLEdBQVE7WUFDWCxHQUFHLEVBQUUsc0RBQXNEO1lBQzNELE1BQU0sRUFBRSxLQUFLO1lBQ2IsT0FBTyxZQUFDLEdBQVE7Z0JBQ2QsSUFBSSxDQUFDLEdBQUcsQ0FBQyxHQUFHLENBQUMsQ0FBQztZQUNoQixDQUFDO1lBQ0QsSUFBSSxZQUFDLElBQVM7Z0JBQ1osSUFBSSxDQUFDLElBQUksQ0FBQyxJQUFJLENBQUMsQ0FBQztZQUNsQixDQUFDO1NBQ0YsQ0FBQztRQUNGLEVBQUUsQ0FBQyxPQUFPLENBQUMsQ0FBQyxDQUFDLENBQUM7SUFDaEIsQ0FBQztJQUNELEdBQUcsWUFBQyxHQUFRO1FBQ1YsT0FBTyxDQUFDLEdBQUcsQ0FBQyxHQUFHLENBQUMsR0FBRyxDQUFDLENBQUE7SUFDdEIsQ0FBQztDQUNGLENBQUMsQ0FBQSIsInNvdXJjZXNDb250ZW50IjpbIi8vbG9ncy5qc1xyXG5cclxuUGFnZSh7XHJcbiAgZGF0YToge1xyXG5cclxuICB9LFxyXG4gIG9uTG9hZCgpIHtcclxuICAgIGxldCB4OiBhbnkgPSB7XHJcbiAgICAgIHVybDogXCJodHRwOi8vMzkuMTA1LjIwNi42OjgwODAvYXBpL1RyZWFzdXJlL0dldFJlY29yZENvdW50XCIsXHJcbiAgICAgIG1ldGhvZDogXCJHRVRcIixcclxuICAgICAgc3VjY2VzcyhyZXM6IGFueSkge1xyXG4gICAgICAgIHRoaXMuc3VjKHJlcyk7XHJcbiAgICAgIH0sXHJcbiAgICAgIGZhaWwoZmFpbDogYW55KSB7XHJcbiAgICAgICAgdGhpcy5mYWlsKGZhaWwpO1xyXG4gICAgICB9XHJcbiAgICB9O1xyXG4gICAgd3gucmVxdWVzdCh4KTtcclxuICB9LFxyXG4gIHN1YyhyZXM6IGFueSkge1xyXG4gICAgY29uc29sZS5sb2cocmVzLmFueSlcclxuICB9XHJcbn0pXHJcbiJdfQ==