mergeInto(LibraryManager.library, {
  SetTime: function (timePointer) { 
    try {

      var timeString = UTF8ToString(timePointer); 
      
      window.dispatchReactUnityEvent("SetTime", timeString);
    } catch (e) {
      console.warn("Failed to dispatch event", e);
    }
  },
});