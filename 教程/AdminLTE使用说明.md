# AdminLT使用说明

## 样式文件的添加

在angular.json中添加如下内容：

```json
    "styles": [
        "./node_modules/admin-lte/bower_components/bootstrap/dist/css/bootstrap.min.css",
        "./node_modules/admin-lte/bower_components/font-awesome/css/font-awesome.min.css",
        "./node_modules/admin-lte/bower_components/Ionicons/css/ionicons.min.css",
        "./node_modules/admin-lte/dist/css/AdminLTE.min.css",
        "./node_modules/admin-lte/dist/css/skins/skin-blue.min.css",
        "./src/styles.css"
    ],
    "scripts": [
        "./node_modules/admin-lte/bower_components/jquery/dist/jquery.min.js",
        "./node_modules/admin-lte/bower_components/bootstrap/dist/js/bootstrap.min.js",
        "./node_modules/admin-lte/dist/js/adminlte.min.js"  
    ]
```

对于原来的start.html进行一下改造:去掉头部和结尾的各种引用，这些引用已经包含在angular.json文件中了

```html
<div class="wrapper">

  <!-- Main Header -->
  <header class="main-header">

      中间部分省略

  <div class="control-sidebar-bg"></div>
</div>  
```
