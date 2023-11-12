using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class lang_manager : MonoBehaviour
{
    public TextMeshProUGUI
        total_text,
        num_mala_count,
        num_mani_count;
    public TextMeshProUGUI
        caption_inc_count_mala,
        yes_inc,
        no_inc;
    //6
    public TextMeshProUGUI
        sounds,
        themes,
        other_setting,
        contact_app_devloper;
    public TextMeshProUGUI
        choose_theme_head,
        save;
    public TextMeshProUGUI
        save_to_calendar,
        save_count;
    public TextMeshProUGUI
        warning_head,
        warning_cap;
    //10
    public TextMeshProUGUI
        month_text,
        yeartext,
        graph_button;

    TextMeshProUGUI error;

    public TextMeshProUGUI[] num_buttonTexts;

    public TextMeshProUGUI
        caption_static,
        caption_changing;
    public TextMeshProUGUI
        num_height_graph,
        num_month_graph,
        graph_height_cap,
        graph_width_cap;

    public TextMeshProUGUI
        settings_head,
        language_but_cap,
        donate,
        delete_data,
        reset_settings;
    public TextMeshProUGUI
        select_audio_head,
        play_text,
        save_text;
    public TextMeshProUGUI
        lang_select_head,
        save_button_cap;
    public TextMeshProUGUI
        delete_data_cap,
        del_data_yes,
        del_data_no;
    public TextMeshProUGUI
        reset_data_head,
        reset_data_cap;
    public TextMeshProUGUI
        quit_app_cap,
        qa_yes,
        qa_no;


    public TextMeshProUGUI user_guide;

    public TextMeshProUGUI[] UG_captions;
    //27
    /// <summary>
    /// 43 tmp's
    /// </summary>

    private static readonly string language_prefs = "language_prefs";
    private static readonly string language_prefs_int = "language_prefs_int";

    /*
        English — USA, UK, Australia, Canada
        Japanese — Japan
        Simplified Chinese — Mainland China, Taiwan, Hong Kong
        Hindi — India
        Russian — Russia
        Korean — South Korea
        German — Germany
        Spanish — Mexico, Argentina
        Portuguese — Brazil
        Indonesian — I
    */

    List<string> m_DropOptions_languages = new List<string> { "English", "日本語", "中国人", "हिंदी", "русский", "한국인", "Deutsch", "Español", "Português", "bahasa Indonesia" };
    List<string> english_tans = new List<string> { "English", "Japanese", "Chinese", "Hindi", "Russian", "Korean", "German", "Spanish", "Portuguese", "Indonesian" };

    //string[] translate_string = new string[44];
    TextMeshProUGUI[] a_translate_string = new TextMeshProUGUI[45];

    string default_app_string;


    public TextMeshProUGUI[] week_shorts;

    void Start()
    {
        grab_data();
        ug_captions = new string[] { eng_ug, jap_ug, chi_ug, hin_ug, rus_ug, kor_ug, ger_ug, spa_ug, por_ug, indo_ug };

        update_lang();


        
    }




    string eng_test = "Total :,0,0,Increment Mala Count?,Yes,No,Sound,theme,other Settings,contact app creator,choose theme ,save,Save to Calendar,Save count,Entry Saved !,Caption Text,January,2023,Graph,Date : \nDay  :\nMala :\nMani :,09 April 2002\nSunday\n201\n108,101,30,count\n,days\n,settings,Language,Donate,Delete data,RESET settings\n,select sound,Play,save,select language,Save,detele all calendar saved data ?,Yes\n,No,RESET,\n\nall settings are resetted !\n\n\n,Quit App?,Yes\n,No,user guide";
    string jap_test = "合計 ：,0,0,マラの数を増やしますか?,はい,いいえ,音,テーマ,その他の設定,アプリ作成者に連絡してください,テーマを選択します,保存,カレンダーに保存します,保存回数,エントリが保存されました!,キャプションテキスト,1月,2023年,グラフ,日付 ：\n日  ：\nマラ：\nマニ：,2002 年 4 月 9 日\n日曜日\n201\n108,101,30,カウント,日々,設定,言語,寄付する,データを削除します,設定をリセット,サウンドを選択します,遊ぶ,保存,言語を選択する,保存,カレンダーに保存されているデータをすべて削除しますか?,はい,いいえ,リセット,すべての設定がリセットされます,アプリを終了しますか?,はい,いいえ,ユーザーガイド";
    string chi_test = "全部的 ：,0,0,增加马拉数？,是的,不,声音,主题,其他设置,联系应用程序创建者,选择主题,节省,保存到日历,保存计数,条目已保存！,标题文字,一月,2023年,图形,日期 ：\n天  ：\n马拉：\n玛尼:,2002 年 4 月 9 日\n星期日\n201\n108,101,30,数数,天,设置,语言,捐,删除数据,重新设置,选择声音,玩,节省,选择语言,节省,删除所有日历保存的数据？,是的,不,重置,所有设置均已重置！,退出应用程序?,是的,不,用户指南";
    string hindi_test = "कुल:,0,0,वृद्धि माला गणना?,हां,नहीं,ध्वनि,थीम,अन्य सेटिंग्स,ऐप निर्माता से संपर्क करें,थीम चुनें,सहेजें,कैलेंडर में सहेजें,गिनती सहेजें,प्रविष्टि सहेजी गई!,कैप्शन टेक्स्ट,जनवरी,2023, ग्राफ़, दिनांक:\nदिन  :\nमाला :\nमणि:, 09 अप्रैल 2002\nरविवार\n201\n108,101,30, गिनती\n,दिन\n,सेटिंग्स,भाषा,दान करें,डेटा हटाएं,रीसेट सेटिंग्स\n, ध्वनि चुनें, चलाएं, सहेजें, भाषा चुनें, सहेजें, सभी कैलेंडर सहेजे गए डेटा को हटाएं?, हां\n,नहीं,रीसेट करें,\n\nसभी सेटिंग्स रीसेट हो गई हैं!\n\n\n,ऐप छोड़ें?, हाँ\n,नहीं,उपयोगकर्ता गाइड";
    string russian_test = "Общий :,0,0,Увеличить количество Мала?,Да,Нет,Звук,тема,другие настройки,связаться с создателем приложения,выбрать тему,сохранять,Сохранить в календарь,Сохранить счетчик,Запись сохранена!,Текст подписи,январь,2023 год,График,Дата: \nДень:\nМала:\nМани:,09 апреля 2002 г.\nвоскресенье\n201\n108,101,30,считать\n,дней\n,настройки,Язык,Пожертвовать,Удалить данные,СБРОС настроек\n,выбрать звук,Играть,сохранять,выберите язык,Сохранять,удалить все сохраненные данные календаря?,Да н,Нет,ПЕРЕЗАГРУЗИТЬ,\n\nвсе настройки сбрасываются!\n\n\n,Выйти из приложения?,Да н,Нет,гид пользователя";
    string korean_test = "합계:,0,0,말라 수 증가?,예,아니요,소리,테마,기타 설정,앱 제작자에게 문의,테마 선택,저장,캘린더에 저장,횟수 저장,항목이 저장됨!,캡션 텍스트,1월,2023, 그래프, 날짜:\n낮  :\n말라 :\n마니:,2002년 4월 9일\n일요일\n201\n108,101,30,카운트\n,날\n,설정,언어,기부,데이터 삭제,설정 재설정\n,소리 선택,재생,저장,언어 선택,저장,캘린더에 저장된 모든 데이터 삭제 ?,예\n,아니요,재설정,\n\n모든 설정이 재설정되었습니다!\n\n\n,앱을 종료하시겠습니까?,예\n,아니요,사용자 설명서";
    string german_test = "Gesamt:,0,0,Mala-Anzahl erhöhen?,Ja,Nein,Ton,Thema,andere Einstellungen,App-Ersteller kontaktieren,Thema auswählen,Speichern,Im Kalender speichern,Anzahl speichern,Eintrag gespeichert!,Beschriftungstext,Januar,2023, Grafik, Datum:\nTag  :\nMala:\nMani:,09. April 2002\nSonntag\n201\n108,101,30,Anzahl\n,Tage\n,Einstellungen,Sprache,Spenden,Daten löschen,Einstellungen ZURÜCKSETZEN\n,Ton auswählen,Wiedergabe,Speichern,Sprache auswählen,Speichern,alle im Kalender gespeicherten Daten löschen?,Ja\n,Nein,RESET,\n\nAlle Einstellungen werden zurückgesetzt!\n\n\n,App beenden?,Ja\n,NEIN,Benutzerhandbuch"; // german

    string spanish_test = "Total :,0,0,¿Incrementar el recuento de Mala?,Sí,No,Sonido,tema,otros ajustes,creador de aplicaciones de contacto,escoge un tema,ahorrar,Guardar en calendario,Guardar recuento,Entrada guardada!,Texto del título,Enero,2023,Grafico,Fecha : \nDía :\nMala :\nMani :,09 de abril de 2002\ndomingo\n201\n108,101,30,contar\n,días\n,ajustes,Idioma,Donar,Borrar datos,RESTABLECER configuración\n,seleccionar sonido,Jugar,ahorrar,seleccione el idioma,Ahorrar,¿Eliminar todos los datos guardados del calendario?,Si n,No,REINICIAR,\n\n¡Todas las configuraciones se restablecen!\n\n\n,¿Salir de la aplicación?,Si n,No,guía del usuario"; //spanish
    string portugese_test = "Total:,0,0,Aumentar a contagem de Mala?,Sim,Não,Som,tema,outros ajustes,entre em contato com o criador do aplicativo,escolha o tema,salvar,Salvar no calendário,Salvar contagem,Entrada salva!,Texto da legenda,Janeiro,2023,Gráfico,Data: \nDia:\nMala:\nMani:,09 de abril de 2002\nDomingo\n201\n108,101,30,contar\n,dias\n,configurações,Linguagem,Doar,Excluir dados,REDEFINIR configurações\n,selecione o som,Jogar,salvar,selecione o idioma,Salvar,excluir todos os dados salvos do calendário?,Sim n,Não,REINICIAR,\n\na todas as configurações foram redefinidas !\n\n\n,Sair do aplicativo?,Sim n,Não,guia de usuario"; // portugese
    string indonesian_test = "Total :,0,0,Tambahkan Jumlah Mala?,Ya,Tidak,Suara,tema,Pengaturan lainnya,hubungi pembuat aplikasi,pilih tema,simpan,Simpan ke Kalender,Simpan jumlah,Entri Disimpan!,Teks Teks,Januari,2023, Grafik, Tanggal :\nHari  :\nMala :\nMani :,09 April 2002\nMinggu\n201\n108,101,30,hitung\n, hari\n,pengaturan,Bahasa,Sumbang,Hapus data,RESET pengaturan\n,pilih suara,Putar,simpan,pilih bahasa,Simpan,hapus semua data yang tersimpan di kalender?,Ya\n, Tidak, SETEL ULANG,\n\nsemua pengaturan disetel ulang!\n\n\n,Keluar dari Aplikasi?,Ya\n,TIDAK,panduan pengguna"; // indonesian







    
    string eng_ug = "you can touch anywhere on screen to count. On touch the number here will increase by 1. After 108, count will be 0 again.+when your counting reaches to 108, this number will increase by 1.+reset button resets all counting back to \"0\".+calendar button shows saved counting data & graph of each day.+save button saves current counting to calendar data OR saves counting on screen.+theme settings, sound settings & other options are here.+To Exit app click here.";
    string jap_ug = "画面上のどこにでもタッチしてカウントできます。タッチすると、ここの数字が 1 ずつ増加します。108 を超えると、カウントは再び 0 になります。+カウントが 108 に達すると、この数字は 1 ずつ増加します。+リセット ボタンを押すと、すべてのカウントが「0」にリセットされます。+カレンダーボタンには、毎日の保存されたカウントデータとグラフが表示されます。+保存ボタンは現在のカウントをカレンダー データに保存するか、カウントを画面上に保存します。+テーマ設定、サウンド設定、その他のオプションはここにあります。+アプリを終了するにはここをクリックしてください。";
    string chi_ug = "您可以触摸屏幕上的任意位置来计数。触摸时，此处的数字将增加 1。108 后，计数将再次为 0。+当你数到108时，这个数字会增加1.+重置按钮将所有计数重置回“0”。+日历按钮显示每天保存的计数数据和图表。+保存按钮将当前计数保存到日历数据或在屏幕上保存计数。+主题设置、声音设置和其他选项都在这里。+要退出应用程序，请单击此处。";
    string hin_ug = "आप गिनने के लिए स्क्रीन पर कहीं भी स्पर्श कर सकते हैं। छूने पर यहां संख्या 1 बढ़ जाएगी. 108 के बाद गिनती फिर 0 हो जाएगी.+जब आपकी गिनती 108 तक पहुंच जाएगी तो यह संख्या 1. बढ़ जाएगी +रीसेट बटन सभी गिनती को वापस \"0\" पर रीसेट कर देता है।+कैलेंडर बटन प्रत्येक दिन का सहेजा गया गणना डेटा और ग्राफ़ दिखाता है।+सेव बटन वर्तमान गिनती को कैलेंडर डेटा में सहेजता है या स्क्रीन पर गिनती बचाता है।+थीम सेटिंग्स, ध्वनि सेटिंग्स और अन्य विकल्प यहां हैं।+ऐप से बाहर निकलने के लिए यहां क्लिक करें।";
    string rus_ug = "вы можете коснуться любого места экрана, чтобы посчитать. При касании число здесь увеличится на 1. После 108 счет снова станет 0.+когда ваш счет дойдет до 108, это число увеличится на 1.+кнопка сброса сбрасывает весь отсчет обратно на «0».+Кнопка календаря показывает сохраненные данные подсчета и график каждого дня.+Кнопка «Сохранить» сохраняет текущий подсчет в данные календаря ИЛИ сохраняет подсчет на экране.+настройки темы, настройки звука и другие параметры здесь.+Чтобы выйти из приложения, нажмите здесь.";

    string kor_ug = "화면의 아무 곳이나 터치하여 계산할 수 있습니다. 터치하면 숫자가 1씩 증가합니다. 108 이후에는 다시 0이 됩니다.+당신의 숫자가 108에 도달하면 이 숫자는 1씩 증가합니다.+재설정 버튼은 모든 카운트를 다시 \"0\"으로 재설정합니다.+달력 버튼을 누르면 저장된 집계 데이터와 날짜별 그래프가 표시됩니다.+저장 버튼은 현재 계산을 달력 데이터에 저장하거나 화면에 계산을 저장합니다.+테마 설정, 사운드 설정 및 기타 옵션이 여기에 있습니다.+앱을 종료하려면 여기를 클릭하세요.";
    string ger_ug = "Sie können eine beliebige Stelle auf dem Bildschirm berühren, um zu zählen. Bei Berührung erhöht sich die Zahl hier um 1. Nach 108 ist die Zählung wieder 0.+Wenn Sie 108 zählen, erhöht sich diese Zahl um 1.+Die Reset-Taste setzt alle Zählungen auf „0“ zurück.+Die Kalenderschaltfläche zeigt gespeicherte Zähldaten und Diagramme für jeden Tag an.+Die Schaltfläche „Speichern“ speichert die aktuelle Zählung in den Kalenderdaten ODER speichert die Zählung auf dem Bildschirm.+Themeneinstellungen, Toneinstellungen und andere Optionen finden Sie hier.+Um die App zu beenden, klicken Sie hier.";
    string spa_ug = "Puedes tocar cualquier lugar de la pantalla para contar. Al tocarlo, el número aquí aumentará en 1. Después de 108, la cuenta volverá a ser 0.+cuando su conteo llegue a 108, este número aumentará en 1.+El botón de reinicio restablece todo el conteo a \"0\".+El botón de calendario muestra los datos de conteo guardados y el gráfico de cada día.+El botón Guardar guarda el conteo actual en los datos del calendario O guarda el conteo en la pantalla.+La configuración del tema, la configuración de sonido y otras opciones están aquí.+Para salir de la aplicación, haga clic aquí.";
    string por_ug = "você pode tocar em qualquer lugar da tela para contar. Ao tocar, o número aqui aumentará em 1. Após 108, a contagem será 0 novamente.+quando sua contagem chegar a 108, esse número aumentará em 1.+o botão reset redefine toda a contagem para \"0\".+o botão do calendário mostra os dados de contagem salvos e o gráfico de cada dia.+o botão salvar salva a contagem atual nos dados do calendário OU salva a contagem na tela.+configurações de tema, configurações de som e outras opções estão aqui.+Para sair do aplicativo, clique aqui.";
    string indo_ug = "Anda dapat menyentuh di mana saja di layar untuk menghitung. Jika disentuh, angka di sini akan bertambah 1. Setelah 108, hitungan akan menjadi 0 lagi.+ketika penghitungan Anda mencapai 108, angka ini akan bertambah 1.+tombol reset mengatur ulang semua penghitungan kembali ke \"0\".+tombol kalender menunjukkan data penghitungan & grafik yang disimpan setiap hari.+tombol simpan menyimpan penghitungan saat ini ke data kalender ATAU menyimpan penghitungan di layar.+pengaturan tema, pengaturan suara & opsi lainnya ada di sini.+Untuk Keluar dari aplikasi klik di sini.";

    string[] ug_captions;









    string[] English_weeks = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
    string[] Japanese_weeks = new string[] { "月", "火", "水", "木", "金", "土", "日" };
    string[] Chinese_weeks = new string[] { "周一", "周二", "周三", "周四", "星期五", "周六", "星期日" };
    string[] Hindi_weeks = new string[] { "सोम", "मंगल", "बुध", "गुरु", "शुक्र", "शनि", "रवि" };
    string[] Russian_weeks = new string[] { "Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс" };

    string[] Korean_weeks = new string[] { "월", "화", "수", "목", "금", "토", "일" };
    string[] German_weeks = new string[] { "Mo", "Di", "Mi", "Do", "Fr", "Sa", "So" };
    string[] Spanish_weeks = new string[] { "Lun", "Mar", "Mié", "Jue", "Vie", "Sáb", "Dom" };
    string[] Portuguese_weeks = new string[] { "Seg", "Ter", "Qua", "Qui", "Sex", "Sáb", "Dom" };
    string[] Indonesian_weeks = new string[] { "Sen", "Sel", "Rab", "Kam", "Jum", "Sab", "Min" };



    string[] English_ug = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
    string[] Japanese_ug = new string[] { "月", "火", "水", "木", "金", "土", "日" };
    string[] Chinese_ug = new string[] { "周一", "周二", "周三", "周四", "星期五", "周六", "星期日" };
    string[] Hindi_ug = new string[] { "सोम", "मंगल", "बुध", "गुरु", "शुक्र", "शनि", "रवि" };
    string[] Russian_ug = new string[] { "Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс" };

    string[] Korean_ug = new string[] { "월", "화", "수", "목", "금", "토", "일" };
    string[] German_ug = new string[] { "Mo", "Di", "Mi", "Do", "Fr", "Sa", "So" };
    string[] Spanish_ug = new string[] { "Lun", "Mar", "Mié", "Jue", "Vie", "Sáb", "Dom" };
    string[] Portuguese_ug = new string[] { "Seg", "Ter", "Qua", "Qui", "Sex", "Sáb", "Dom" };
    string[] Indonesian_ug = new string[] { "Sen", "Sel", "Rab", "Kam", "Jum", "Sab", "Min" };


    void assign_lang_text(string inp_data, string ug_cpas_inb)
    {
        string[] tmp_txt = inp_data.Split(",");

        for (int i = 0; i <= tmp_txt.Length; i++)
        {
            if(i < 19)
            {
                a_translate_string[i].SetText(tmp_txt[i]);
            } else if (i == 19)
            {
            } else
            {
                a_translate_string[i].SetText(tmp_txt[i-1]);
            }
        }

        string[] ug_cpas_distr = ug_cpas_inb.Split("+");

        for(int i =0; i < UG_captions.Length; i++)
        {
            UG_captions[i].SetText(ug_cpas_distr[i]);
        }
    }


    public void update_week_shorts()
    {
        int lang = PlayerPrefs.GetInt(language_prefs_int);
        string[] week_string;

        switch (lang)
        {
                
            case 1:
                {
                    week_string = Japanese_weeks;
                    break;
                }
            case 2:
                {
                    week_string = Chinese_weeks;
                    break;
                }
            case 3:
                {
                    week_string = Hindi_weeks;
                    break;
                }
            case 4:
                {
                    week_string = Russian_weeks;
                    break;
                }
            case 5:
                {
                    week_string = Korean_weeks;
                    break;
                }
            case 6:
                {
                    week_string = German_weeks;
                    break;
                }
            case 7:
                {
                    week_string = Spanish_weeks;
                    break;
                }
            case 8:
                {
                    week_string = Portuguese_weeks;
                    break;
                }
            case 9:
                {
                    week_string = Indonesian_weeks;
                    break;
                }
            default:
                {
                    week_string = English_weeks;
                    break;
                }
        }

        for(int i =0; i < week_shorts.Length; i++)
        {
            week_shorts[i].SetText(week_string[i]);
        }
    }

    void grab_data()
    {
        a_translate_string[0] = total_text;
        a_translate_string[1] = num_mala_count;
        a_translate_string[2] = num_mani_count;
        a_translate_string[3] = caption_inc_count_mala;
        a_translate_string[4] = yes_inc;
        a_translate_string[5] = no_inc;



        a_translate_string[6] = sounds;
        a_translate_string[7] = themes;
        a_translate_string[8] = other_setting;
        a_translate_string[9] = contact_app_devloper;
        a_translate_string[10] = choose_theme_head;
        a_translate_string[11] = save;
        a_translate_string[12] = save_to_calendar;
        a_translate_string[13] = save_count;
        a_translate_string[14] = warning_head;
        a_translate_string[15] = warning_cap;

        a_translate_string[16] = month_text;
        a_translate_string[17] = yeartext;
        a_translate_string[18] = graph_button;

        a_translate_string[19] = test_str;

        a_translate_string[20] = caption_static;
        a_translate_string[21] = caption_changing;
        a_translate_string[22] = num_height_graph;
        a_translate_string[23] = num_month_graph;
        a_translate_string[24] = graph_height_cap;
        a_translate_string[25] = graph_width_cap;

        a_translate_string[26] = settings_head;
        a_translate_string[27] = language_but_cap;
        a_translate_string[28] = donate;
        a_translate_string[29] = delete_data;
        a_translate_string[30] = reset_settings;
        a_translate_string[31] = select_audio_head;
        a_translate_string[32] = play_text;
        a_translate_string[33] = save_text;
        a_translate_string[34] = lang_select_head;
        a_translate_string[35] = save_button_cap;
        a_translate_string[36] = delete_data_cap;
        a_translate_string[37] = del_data_yes;
        a_translate_string[38] = del_data_no;
        a_translate_string[39] = reset_data_head;
        a_translate_string[40] = reset_data_cap;
        a_translate_string[41] = quit_app_cap;
        a_translate_string[42] = qa_yes;
        a_translate_string[43] = qa_no;
        a_translate_string[44] = user_guide;

    }

    public TextMeshProUGUI test_str;

    public void update_lang()
    {
        int selected_language = PlayerPrefs.GetInt(language_prefs_int);
        string default_lang_set = "";

        switch (selected_language)
        {
            case 1:
                {
                    default_lang_set = jap_test;
                    break;
                }

            case 2:
                {
                    default_lang_set = chi_test;
                    break;
                }

            case 3:
                {
                    default_lang_set = hindi_test;
                    break;
                }

            case 4:
                {
                    default_lang_set = russian_test;
                    break;
                }

            case 5:
                {
                    default_lang_set = korean_test;
                    break;
                }

            case 6:
                {
                    default_lang_set = german_test;
                    break;
                }

            case 7:
                {
                    default_lang_set = spanish_test;
                    break;
                }

            case 8:
                {
                    default_lang_set = portugese_test;
                    break;
                }

            case 9:
                {
                    default_lang_set = indonesian_test;
                    break;
                }
            default:
                {
                    default_lang_set = eng_test;
                    break;
                }
        }

        assign_lang_text(default_lang_set, ug_captions[selected_language]);


    }
}
