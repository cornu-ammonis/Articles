﻿$(function () {

    var Articles = {};

    Articles.GridManager = {

        postsGrid: function (gridName, pagerName) {

        },

        categoriesGrid: function (gridName, pagerName) {

        },

        tagsGrid: function (gridName, pagerName) {

        }
    };

    $("#tabs").tabs({
        show: function (event, ui)
        {
            if (!ui.tab.isLoaded) {
                var gdMgr = Articles.GridManager, fn, gridName, pagerName;

                switch (ui.index) {
                    case 0:
                        fn = gdMgr.postsGrid;
                        gridName = "#tablePosts";
                        pagerName = "#pagerPosts";
                        break;
                    case 1:
                        fn = gdMgr.categoriesGrid;
                        gridName = "#tableCats";
                        pagerName = "#pagerCats";
                        break;
                    case 2:
                        fn = gdMgr.tagsGrid;
                        gridName = "tableTags";
                        pagerName = "pagerTags";   
                        break;
                };
                fn(gridName, pagerName);
                ui.tab.isLoaded = true;
            }
        }


    });
});