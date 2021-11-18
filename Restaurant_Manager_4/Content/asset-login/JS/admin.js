$(document).ready(function(){
    showMenu();
});

function showMenu(){

    $('.danhmuc>.danhmuc_menu-list').click(function(){
        if($(this).hasClass('active')){
            $(this).children(' .danhsach_list').slideUp();
            $(this).removeClass('active');
            $(this).removeClass('loaibopadding_danhmuc_list');
        }else{
            $(' .danhsach_list').slideUp();
            $(this).children(' .danhsach_list').slideDown();
            $(' .danhmuc>.danhmuc_menu-list').removeClass('active');
            $(' .danhmuc>.danhmuc_menu-list').removeClass('loaibopadding_danhmuc_list');
            $(this).addClass('loaibopadding_danhmuc_list');
            $(this).addClass('active');
        }
    });
}
