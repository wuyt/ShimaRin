mergeInto(LibraryManager.library, {
  GetFromUnity: function (info) {
    document.getElementById("ShowInfo").value=UTF8ToString(info);
  },
});