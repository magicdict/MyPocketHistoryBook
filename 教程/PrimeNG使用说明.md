# PrimeNG使用说明

## AdminLTE的导入

在package.json下面添加如下条目：
    "primeicons": "^2.0.0",
    "primeng": "^8.0.2",

## 样式文件的添加

在angular.json中添加如下内容：
假设这里使用的是 rhea 这个免费主题

```json
"styles": [
    "./node_modules/primeng/resources/primeng.min.css",
    "./node_modules/primeng/resources/themes/rhea/theme.css",
    "./node_modules/primeicons/primeicons.css",
],
```

对于不同的空间，使用的时候需要import不同的module才可以正常工作，例如Table控件

```typescript

//Third party component
import { TableModule } from 'primeng/table';

  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    TableModule
  ],

```
