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
import {TuiSvgModule} from '@taiga-ui/core';
import { BurgerButtonComponent } from './components/burger-button/burger-button.component';
import {TuiAccordionModule} from '@taiga-ui/kit';
import {TuiSidebarModule} from '@taiga-ui/addon-mobile';
import {TuiActiveZoneModule} from '@taiga-ui/cdk';
import { SidenavComponent } from './components/sidenav/sidenav.component';
import {RouterModule} from '@angular/router';
import { ProblemsComponent } from './pages/problems/problems.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { ProblemComponent } from './pages/problem/problem.component';
import { CourseComponent } from './pages/course/course.component';
import { FilterComponent } from './components/filter/filter.component';
import { CodeEditorComponent } from './components/code-editor/code-editor.component';
import { MonacoEditorModule } from 'ngx-monaco-editor-v2';
import {TuiDataListWrapperModule, TuiMultiSelectModule} from '@taiga-ui/kit';

@NgModule({
  declarations: [
    AppComponent,
    ProblemsTableComponent,
    ChartsIslandsComponent,
    MainHeaderComponent,
    BurgerButtonComponent,
    SidenavComponent,
    ProblemsComponent,
    ProfileComponent,
    ProblemComponent,
    CourseComponent,
    FilterComponent,
    CodeEditorComponent
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
    TuiSvgModule,
    TuiAccordionModule,
    TuiSidebarModule,
    TuiActiveZoneModule,
    MonacoEditorModule,
    TuiDataListWrapperModule,
    TuiMultiSelectModule,
    MonacoEditorModule.forRoot(),
    RouterModule,
    RouterModule.forRoot([
      {path: 'problems', component: ProblemsComponent},
      {path: 'profile', component: ProfileComponent},
      {path: 'course', component: CourseComponent},
      {path: 'problem/:id', component: ProblemComponent},
      {path: '', redirectTo: '/problems', pathMatch: 'full'},
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
