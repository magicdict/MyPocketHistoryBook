# HttpClient使用说明

## 官方教程（英文原版）：<https://angular.io/guide/http>

要使用HttpClient,首先要将HttpClientModule导入进来。

```typescript
import { HttpClientModule } from '@angular/common/http';

imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    TableModule
],

```

考虑到HttpClient需要被很多地方使用，一般会把Http访问Restful Api封装为一个服务：

```typescript
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class CommonFunction {

    constructor(
        private http: HttpClient
    ) { }

    private webapiurl = "http://39.105.206.6:8080/api/";

    public httpRequest<T>(serviceUrl: string): Promise<T> {
        return this.http.get(
            this.webapiurl + serviceUrl
        )
            .toPromise()
            .then(response => {
                return response as T;
            })
            .catch(this.handleError);
    }

    public httpRequestPost<T>(serviceUrl: string, params: any = {}): Promise<T> {
        return this.http.post(
            this.webapiurl + serviceUrl,
            params
        )
            .toPromise()
            .then(response => {
                return response as T;
            })
            .catch(this.handleError);
    }

    handleError(error: any): Promise<any> {
        console.error('服务器访问失败', error);
        return Promise.reject(error.message || error);
    }
}
```

使用例子如下：

```typescript

@Injectable()
export class ITreasureResolver implements Resolve<ITreasure[]> {
    constructor(public commonFunction: CommonFunction) {

    }
    resolve(route: ActivatedRouteSnapshot, _state: RouterStateSnapshot): ITreasure[] | Observable<ITreasure[]> | Promise<ITreasure[]> {
        return this.commonFunction.httpRequest<ITreasure[]>("Treasure");
    }
}

```
