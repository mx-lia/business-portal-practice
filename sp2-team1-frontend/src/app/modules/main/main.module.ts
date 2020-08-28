import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {SharedModule} from '@app/modules/shared/shared.module';
import {MainComponent} from './main.component';
import {MainRoutingModule} from '@app/modules/main/main-routing.module';
import {DatagridComponent} from './components/datagrid/datagrid.component';
import {DialogboxComponent} from './components/dialogbox/dialogbox.component';
import {LoaderComponent} from './components/loader/loader.component';

@NgModule({
  imports: [
    CommonModule,
    MainRoutingModule,
    SharedModule
  ],
  declarations: [MainComponent, DatagridComponent, DialogboxComponent, LoaderComponent],
  entryComponents: [
    DialogboxComponent
  ]
})
export class MainModule {
}
