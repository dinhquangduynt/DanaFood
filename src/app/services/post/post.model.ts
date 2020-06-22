import { DateAdapter } from '@angular/material/core';

export class PostCategory {
   ID : number;
   Name : string;
   Alias : string;
   Description : string;
   DisplayOrder : number;
   Image : string;
   HomeFlag: boolean;
   Posts : string;
   CreatedBy : string;
   CreatedDate : Date;
   UpdatedBy : string;
   UpdatedDate: Date;
   Status : boolean;
}
