import { Injectable } from '@angular/core';
import { CommonFunction } from './common';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { ITreasure } from './interface/ITreasure';

@Injectable()
export class ITreasureResolver implements Resolve<ITreasure[]> {
    constructor(public commonFunction: CommonFunction) {

    }
    resolve(route: ActivatedRouteSnapshot, _state: RouterStateSnapshot): ITreasure[] | Observable<ITreasure[]> | Promise<ITreasure[]> {
        return this.commonFunction.httpRequest<ITreasure[]>("Treasure");
    }
}