import {
  Component,
  HostListener,
  ElementRef,
  Input,
  Output,
  EventEmitter
} from "@angular/core";

@Component({
  selector: "tooltip-a",
  templateUrl: "./tooltip-a.component.html",
  styleUrls: ["./tooltip-a.component.css"]
})
export class TooltipAComponent {
  constructor(private eRef: ElementRef) {}
  tltpAVisiblity: boolean;
  @Input()
  tltpAIsVisible: boolean;
  @Output()
  visiblity = new EventEmitter<boolean>();

  @HostListener("window:mouseup", ["$event"])
  clickout(event) {
    if (!this.eRef.nativeElement.contains(event.target)) {
      this.tltpAVisiblity = false;
      this.visiblity.emit(this.tltpAVisiblity);
    }
  }
}
