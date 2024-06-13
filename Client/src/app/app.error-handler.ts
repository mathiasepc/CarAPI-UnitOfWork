import { ErrorHandler, Inject, Injectable } from "@angular/core";
import { NOTYF } from 'src/app/Shared/notyf.token';
import { Notyf } from 'notyf';

/*
Denne class griber alle fejl

*/ 

@Injectable({
    providedIn: 'root' 
  })

export class appErrorHandler implements ErrorHandler{

    constructor(
        @Inject(NOTYF) private notyf: Notyf){}

    handleError(error: any): void {
        this.notyf.error("noget gik galt.");
    }
}