import {
  Component,
  HostListener,
  ElementRef,
  Input,
  Output,
  EventEmitter
} from "@angular/core";

@Component({
  selector: "tooltip-b",
  templateUrl: "./tooltip-b.component.html",
  styleUrls: ["./tooltip-b.component.css"]
})
export class TooltipBComponent {
  constructor(private eRef: ElementRef) {}

  tltpBVisiblity: boolean;
  @Input()
  tltpBIsVisible: boolean;
  @Output()
  visiblity = new EventEmitter<boolean>();

  @HostListener("window:mouseup", ["$event"])
  clickout(event) {
    if (!this.eRef.nativeElement.contains(event.target)) {
      this.tltpBVisiblity = false;
      this.visiblity.emit(this.tltpBVisiblity);
    }
  }
}
