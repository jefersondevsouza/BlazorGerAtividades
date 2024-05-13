import{p as t,R as e,c as i}from"./dom-utils-7f5be2f0.js";import{D as n}from"./dom-166a04be.js";import{E as s}from"./eventRegister-fb9b0e47.js";import{D as a}from"./dx-html-element-base-7f87ceb0.js";import"./css-classes-f3f8ed66.js";import"./_tslib-6e8ca86b.js";import"./data-qa-utils-8be7c726.js";import"./dx-html-element-pointer-events-helper-0f2b6602.js";import"./eventhelper-8570b930.js";var h;!function(t){t[t.None=0]="None",t[t.Slide=1]="Slide"}(h||(h={}));class o extends a{constructor(){super(),this.isAnimating=!1,this.mutationObserver=null,this._expanded=!0,this._animationType=h.None,this.events=new s(this),this.contentFirstRender=!0}get expanded(){return this._expanded}set expanded(t){this._expanded!==t&&(this._expanded=t,this.applyExpandedStateToElements())}get animationType(){return this._animationType}set animationType(t){this._animationType!==t&&(this._animationType=t)}initializeComponent(){const t=this.isInitialized;super.initializeComponent(),t&&!this.contentFirstRender||this.applyExpandedStateToElements()}notifyActualExpandedChanged(){this.dispatchEvent(new Event("change",{bubbles:!0}))}get value(){return Boolean(this.expanded).toString()}static get observedAttributes(){return["expanded-state","animation-type"]}attributeChangedCallback(t,e,i){switch(t){case"expanded-state":this.expanded="true"===(null==i?void 0:i.toLowerCase());break;case"animation-type":this.animationType=h[i]}}applyExpandedStateToElements(){var t;const e=this.expanded;if(!this.isInitialized)return this.notifyActualExpandedChanged(),void this.setContainerElementVisibility(e);if(this.animationType===h.None)return this.notifyActualExpandedChanged(),this.setContainerElementVisibility(e),void(this.contentFirstRender=!1);if(e&&0===this.childElementCount)return void this.waitForContent(this);if(e&&0!==this.childElementCount&&null!==this.firstElementChild&&this.firstElementChild.hasAttribute("data-items-container")&&0===this.firstElementChild.childElementCount)return void this.waitForContent(this.firstElementChild);this.contentFirstRender=!1;const i=this.token,n=e&&!i?0:this.getContainerStartHeight(e);this.toggleAttribute("is-animating",!1),i&&(this.style.maxHeight=n+"px");const s=this.getContainerEndHeight(e);if(this.prepareElementsForAnimation(e,0,!!i),null===(t=this.token)||void 0===t||t.dispose(),this.token=null,n!==s){const t=()=>{this.token.dispose(),this.token=null,this.onAnimationComplete()};this.startAnimation(n,s,(()=>{t()}))}else this.onAnimationComplete()}waitForContent(t){var e;null===(e=this.mutationObserver)||void 0===e||e.disconnect(),this.mutationObserver=new MutationObserver((t=>{var e;this.applyExpandedStateToElements(),null===(e=this.mutationObserver)||void 0===e||e.disconnect()})),this.mutationObserver.observe(t,{childList:!0})}setContainerElementVisibility(t){this.setElementVisibility(t)}setElementVisibility(t){t?(this.style.visibility="",this.style.height=""):(this.style.visibility="hidden",this.style.height="0px")}getContainerStartHeight(t){return t?this.getClearClientHeight():this.offsetHeight}getContainerEndHeight(t){if(!t)return 0;const e=this.getClearClientHeight(),i=this.getElementVisibility(!1);this.style.maxHeight="",this.setElementVisibility(!0);const n=this.getClearClientHeight();return this.setElementVisibility(i),this.style.maxHeight=e+"px",n}prepareElementsForAnimation(t,e,i){if(this.style.overflow="hidden",t)this.style.maxHeight=(i?0:this.getClearClientHeight())+"px",this.setContainerElementVisibility(!0);else{const t=this.offsetHeight+e;t>=0&&this.setOffsetHeight(t,null)}}getClearClientHeight(){return this.offsetHeight}getElementVisibility(t){if(t){const t=n.getCurrentStyle(this);if(t)return"hidden"!==t.visibility}return"hidden"!==this.style.visibility}setOffsetHeight(e,i){i||(i=n.getCurrentStyle(this));let s=e-n.pxToInt(i.marginTop)-n.pxToInt(i.marginBottom);s-=t(this,i),s>-1&&(this.style.maxHeight=s+"px")}startAnimation(t,i,n){this.isAnimating=!0,t!==i?(this.token=this.events.attachEvent(this,"transitionend",n),e((()=>{this.isAnimating&&(this.toggleAttribute("is-animating",!0),this.style.maxHeight=i+"px")}))):n()}onAnimationComplete(){this.setContainerElementVisibility(this.expanded),this.toggleAttribute("is-animating",!1),i((()=>{this.style.overflow="",this.style.maxHeight=""})),this.notifyActualExpandedChanged()}}customElements.define("dxbl-expandable-container",o);const l={loadModule:function(){}};export{o as ExpandableContainer,l as default};
