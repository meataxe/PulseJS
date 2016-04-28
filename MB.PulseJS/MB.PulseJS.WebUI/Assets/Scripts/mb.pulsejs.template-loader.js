var templateLoader = (function ($, host, console) {
  //Loads external templates from path and injects in to page DOM
  return {
    loadExtTemplate: function (path) {
      var tmplLoader = $.get(path)
          .success(function (result) {
            //Add templates to DOM
            $("body").append(result);
          })
          .error(function (result) {
            console.log("Error Loading Templates", result);
          })

      tmplLoader.complete(function () {
        $(host).trigger("FEED_MANAGER_TEMPLATE_LOADED", [path]);
      });
    }
  };
})(jQuery, document, console);