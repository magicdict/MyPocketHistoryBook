import { Injectable } from '@angular/core';
import { CommonFunction } from './common';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { ITreasure } from './interface/ITreasure';
import { IEvent } from './interface/IEvent';
import { IPersonage } from './interface/IPersonage';

@Injectable()
export class ITreasureResolver implements Resolve<ITreasure[]> {
    constructor(public commonFunction: CommonFunction) {

    }
    resolve(route: ActivatedRouteSnapshot, _state: RouterStateSnapshot): ITreasure[] | Observable<ITreasure[]> | Promise<ITreasure[]> {
        return this.commonFunction.httpRequest<ITreasure[]>("Treasure");
    }
}

@Injectable()
export class IEventResolver implements Resolve<IEvent[]> {
    constructor(public commonFunction: CommonFunction) {

    }
    resolve(route: ActivatedRouteSnapshot, _state: RouterStateSnapshot): IEvent[] | Observable<IEvent[]> | Promise<IEvent[]> {
        return this.commonFunction.httpRequest<IEvent[]>("Event");
    }
}

@Injectable()
export class IPersonageResolver implements Resolve<IPersonage[]> {
    constructor(public commonFunction: CommonFunction) {

    }
    resolve(route: ActivatedRouteSnapshot, _state: RouterStateSnapshot): IPersonage[] | Observable<IPersonage[]> | Promise<IPersonage[]> {
        return this.commonFunction.httpRequest<IPersonage[]>("Personage");
    }
}