import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { AppComponent } from "./app.component";
import { ButtonFormComponent } from "./button-form/button-form.component";
import { HomeComponent } from "./home/home.component";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { TooltipAComponent } from "./tooltip-a/tooltip-a.component";
import { TooltipBComponent } from "./tooltip-b/tooltip-b.component";

const routes: Routes = [
  { path: "", component: HomeComponent },
  { path: "buttons", component: ButtonFormComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    ButtonFormComponent,
    HomeComponent,
    TooltipAComponent,
    TooltipBComponent
  ],
  imports: [NgbModule, BrowserModule, RouterModule.forRoot(routes)],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
