import { Component, HostListener } from "@angular/core";

@Component({
  selector: "app-button-form",
  templateUrl: "./button-form.component.html",
  styleUrls: ["./button-form.component.css"]
})
export class ButtonFormComponent {
  tltpAVisiblity: boolean = false;
  tltpBVisiblity: boolean = false;
  key: any;
  constructor() {}

  buttonAClicked() {
    if (!this.tltpAVisiblity) this.tltpAVisiblity = true;
    this.tltpBVisiblity = false;
  }
  buttonBClicked() {
    if (!this.tltpBVisiblity) this.tltpBVisiblity = true;
    this.tltpAVisiblity = false;
  }

  resetToolTips() {
    this.tltpAVisiblity = false;
    this.tltpBVisiblity = false;
  }

  recieveClickToolOnTipA($event) {
    if (!$event && this.tltpAVisiblity) this.resetToolTips();
  }

  recieveClickToolOnTipB($event) {
    if (!$event && this.tltpBVisiblity) this.resetToolTips();
  }

  @HostListener("document:keydown", ["$event"])
  handleKeyboardEvent(event: KeyboardEvent) {
    this.key = event.key;
    if (event.key === "Escape") {
      this.resetToolTips();
    }
  }
}
