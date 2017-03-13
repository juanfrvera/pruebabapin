Alert('a');

$(function() {
$('span.threestate')
      .log('checkboxes')
      .each(function() {
          var thespan = $(this);
          var checkbox = $(thespan.children().get(0));
          var name = checkbox.attr('id') + '_hf';

          var innerhf = $('<input type="hidden" name="' + name + '" id="' + name + '" />');
          thespan.prepend(innerhf);

          var innerslide = $('<div style="width:' + thespan.width() + 'px; height:' + thespan.height() + 'px" class="chboverlay" />')
          .css('opacity', 0.8)
              .click(function() {
                  //debugger;
                  if (innerhf.val() == 2) {
                      $(this).css('opacity', 0.0)
                      checkbox.attr('checked', true);
                      innerhf.val(1);
                  } else {
                      if (innerhf.val() == 1) {
                          checkbox.attr('checked', false);
                          innerhf.val(0);
                      } else {
                          $(this).css('opacity', 0.8)
                          checkbox.attr('checked', false);
                          innerhf.val(2);
                      }
                  }
              });
          var chkvalue = "2";
      
          if (checkbox.parent().attr('threestatevalue') != undefined) {
              chkvalue = checkbox.parent().attr('threestatevalue');
              if (chkvalue == "0" || chkvalue == "1") {
                  innerslide.css('opacity', 0.0)
              }
          }
          innerhf.val(chkvalue);
          thespan.prepend(innerslide);
      });