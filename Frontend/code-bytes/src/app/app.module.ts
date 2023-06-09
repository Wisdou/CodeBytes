import {NgModule} from '@angular/core';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {TuiRootModule} from '@taiga-ui/core';
import {TuiTableModule} from '@taiga-ui/addon-table';
import {TuiTagModule} from '@taiga-ui/kit';
import {TuiIslandModule} from '@taiga-ui/kit';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProblemsTableComponent } from './components/problems-table/problems-table.component';
import {TuiLetModule} from '@taiga-ui/cdk';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {TuiToggleModule} from '@taiga-ui/kit';
import { ChartsIslandsComponent } from './components/charts-islands/charts-islands.component';
import { MainHeaderComponent } from './components/main-header/main-header.component';
import {TuiAvatarModule} from '@taiga-ui/kit';
import {TuiRingChartModule} from '@taiga-ui/addon-charts';
import { HttpClientModule } from '@angular/common/http';
import {TuiTablePaginationModule} from '@taiga-ui/addon-table';
import {TuiInputModule} from '@taiga-ui/kit';
import {TuiLoaderModule} from '@taiga-ui/core';

@NgModule({
  declarations: [
    AppComponent,
    ProblemsTableComponent,
    ChartsIslandsComponent,
    MainHeaderComponent
  ],
  imports: [
    BrowserAnimationsModule,
    TuiRootModule,
    AppRoutingModule,
    TuiTableModule,
    TuiTagModule,
    TuiLetModule,
    TuiIslandModule,
    FormsModule,
    ReactiveFormsModule,
    TuiToggleModule,
    TuiAvatarModule,
    TuiRingChartModule,
    HttpClientModule,
    TuiTablePaginationModule,
    TuiInputModule,
    TuiLoaderModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
