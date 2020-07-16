using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace LiMarket_V1._0._0.Models
{
    public class Initializer: DropCreateDatabaseAlways<MsContext>
    {
        protected override void Seed(MsContext db)
        {

            
           
            var g1 = new Genre();
            var g2 = new Genre();
            var g4 = new Genre();
            var g5 = new Genre();
            
            db.SaveChanges();
            var b1 = new Book {  Name = "Гаррі Поттер і філософський камінь", NumPages = 320, Description = "Нове видання вже добре відомої шанувальникам першої частини пригод незвичайного хлопчика Гаррі Поттера. Книга була вперше видана у 1997 році, і тепер діти, які виросли з нею, читають її своїм дітям чи перечитують для задоволення, адже кожен, хто стикнувся з цим чаклунським світом, вже не зможе уявити, ніби не має цього досвіду. Кожен з нас хотів навчатися в Хогвартсі і мати таких розумних і відчайдушних друзів, випробувати свою мужність в небезпечних пригодах", AddDate = DateTime.Now, Price = 460, Popularity = 0, IsAvaible = true, Year = 2017 };
            var b2 = new Book {  Name = "Чарлі і шоколадна фабрика", NumPages = 240, Description = "Всем поклонникам творчества суперпопулярной Джоан Роулинг, без сомнения, будет интересно познакомиться с этой книгой, автора которой, Роальда Дала, принято считать «литературным отцом» знаменитой писательницы. Хотя, возможно, этот сюжет вам уже знаком, ведь «Чарли и шоколадная фабрика» - самая популярная книга Дала. Бедному мальчику, на каждый день рождения получавшему в подарок лишь маленький шоколадный батончик, предстоит удивительное приключение, ведь его доброта служит примером для других, а добро всегда получает свою награду", AddDate = DateTime.Now, Price = 140, Popularity = 0, IsAvaible = true, Year = 2009 };
            var b3 = new Book {  Name = "Гаррі Поттер i в’язень Азкабану", NumPages = 384, Description = "Написана Джоан Роулінг книга «Гаррі Поттер і в'язень Азкабану» - третя книга про пригоди Хлопчика-зі-шрамом, яка підкорила цілий світ! Гаррі Поттер - незвичайний хлопчик. Він дуже не любить літні канікули, адже цей час він проводить в будинку своїх дядька й тітки Дурслі. А вони терпіти не можуть чарівників. Одного разу, втікши від ненависних родичів, Гаррі підбирає автобус «Нічний Лицар», який везе його прямісінько до рятівного магічного світу. Але тепер він не такий безпечний як раніше. Через дванадцять довгих років на свободу вибрався найнебезпечніший злочинець в'язниці Азкабан і спадкоємець самого Волан-де-Морта - Сіріус Блек! Кажуть, ніби це він зрадив Джеймса та Лілі Поттер, а тепер шукає самого Гаррі щоб закінчити почате Темним Лордом. Для охорони Гоґвортсу були покликані жахливі дементори - вартові Азкабану. Але чи зможуть вони захистити учнів? Адже є зрадник, який готовий відкрити шлях злочинцеві ... У 3 книзі Гаррі Поттеру і його друзям, Рону і Герміоні, доведеться знову зіткнутися зі злими чарами і розкрити старі секрети.", AddDate = DateTime.Now, Price = 160, Popularity = 0, IsAvaible = true, Year = 2017 };
            var b4 = new Book {  Name = "Гобіт, або Туди і звідти", NumPages = 384, Description = "Це історія надзвичайної пригоди, яку втнула ватага ґномів, узявшись відшукати загарбане драконом золото. Мимохіть учасником цієї ризикованої виправи став Більбо Торбин, прихильний до комфорту і позбавлений амбіцій гобіт, котрий, на власний подив, виявив неабияку винахідливість і вправність у ролі зломщика. Сутички з тролями, ґоблінами, ґномами, ельфами та гігантськими павуками, бесіда з драконом, Смоґом Величним, і радше мимовільна присутність на Битві П’ятьох Армій — ось лише деякі пригоди, що їх судилося пережити Більбо. Але траплялись і світліші моменти: щира дружба, смачне частування, сміх та пісні. Написаний професором Толкіном для власних дітей, «Гобіт» відразу ж по виході у світ зустрів палке схвалення. Ця дивовижна історія, цілком закінчена та вивершена, водночас є преамбулою до «Володаря Перстнів».", AddDate = DateTime.Now, Price = 180, Popularity = 0, IsAvaible = true, Year = 2015 };
            var b5 = new Book {  Name = "Відьмак. Останнє бажання", NumPages = 288, Description = "Біловолосий відьмак Ґеральт із Рівії, один з небагатьох представників колись численного цеху захисників людської раси від породжень нелюдського зла, мандрує невеликими королівствами, які можна охопити поглядом з вежі замку, та великими містами, отримуючи платню за те, чого навчений, - знищення віїв і з'ядарок, стриґ та віпперів. Але є у відьмака і власний кодекс, у якому вбивство - це лише крайня міра, а життя розумне, чим би воно не було, - це все-таки життя. Саме цим він наживає собі нових ворогів, але й знаходить друзів, які колись змінять його долю.", AddDate = DateTime.Now, Price = 140, Popularity = 0, IsAvaible = true, Year = 2016 };
            var b6 = new Book {  Name = "Мандрівний замок Хаула", NumPages = 352, Description = "Зла відьма перетворює Софі на старезну бабусю. Дівчина потрапляє в таємничий замок чарівника Хаула і укладає угоду з вогняним демоном, завдяки якому i рухається замок. На шляху до звільнення від закляття Софі доведеться розгадати багато загадок та побороти численні перешкоди...", AddDate = DateTime.Now, Price = 120, Popularity = 0, IsAvaible = true, Year = 2015 };
            var b7 = new Book {  Name = "Квіти для Елджернона", NumPages = 304, Description = "Чарлі Гордон — розумово відсталий, але у нього є друзі, робота, захоплення і непереборне бажання вчитися. Він погоджується взяти участь у небезпечному науковому експерименті, який може зробити його найрозумнішим... Яку ціну маємо ми платити за свої бажання? Чи варті вони того? Пронизлива історія, яка нікого не залишить байдужим! Мабуть, один з найлюдяніших творів у світовій літературі.", AddDate = DateTime.Now, Price = 150, Popularity = 0, IsAvaible = true, Year = 2020 };
            var b8 = new Book {  Name = "Мастер и Маргарита", NumPages = 427, Description = "«Майстер і Маргарита» - головний роман Булгакова, книга на всі часи, яка чекала свого видання 50 років. Це історія про диявола і його свиту, які відвідали Москву 1930-х, про прокуратора Юдеї Понтія Пілата і злиденного філософа Ієшуа Га-Ноцрі, про талановитого майстра і його прекрасну і вірну кохану Маргариту. Філософська глибина роману поєднується із захопливим сюжетом, а іронічний погляд автора - з вірою в вічні цінності, без яких неможливе життя людини.", AddDate = DateTime.Now, Price = 120, Popularity = 0, IsAvaible = true, Year = 2018 };
            var b9 = new Book {  Name = "Таємнича історія Біллі Міллігана", NumPages = 512, Description = "Біллі прокидається і виявляє, що знаходиться в тюремній камері. Йому повідомляють, що він звинувачується у зґвалтуванні і пограбуванні. Біллі вражений: він нічого цього не робив! Останнє, що він пам'ятає, - це як він стоїть на даху будівлі школи і хоче кинутися вниз, тому що не може більше так жити. Йому кажуть, що з тих пір пройшло сім років. Біллі обіймає жах: ...", AddDate = DateTime.Now, Price = 140, Popularity = 0, IsAvaible = true, Year = 2016 };
            var b10 = new Book {  Name = "Аеропорт", NumPages = 544, Description = "Генеральний директор Міжнародного аеропорту Лінкольна Мел Бейкерсфелд і не помітив, як увійшов у круте життєве піке. Негаразди вдома підсилилися негараздами на роботі: «Боїнг-707» застряг на одній зі злітних смуг. Тим часом Рейс Два «Транс Америка» починає набирати пасажирів. Пілот навіть не підозрює, що єдиною смугою для посадки є саме заблокована «Боїнгом». Але все це абсолютно нічого не важить, коли до аеропорту заходить чоловік, що запланував підірвати себе в одному з рейсів. Він уже поклав вибухівку до своєї валізки, він уже на борту літака…", AddDate = DateTime.Now, Price = 165, Popularity = 0, IsAvaible = true, Year = 2018 };
            var b11 = new Book { Name = "Unknown test", NumPages = 0, Price = 0, Year = 0, AddDate = DateTime.Now, Popularity = 0, IsAvaible = true };

            b1.Images.Add(new Image { Alt = "Гаррі Поттер і філософський камінь", Url = "https://img.yakaboo.ua/media/catalog/product/cache/1/image/398x565/234c7c011ba026e66d29567e1be1d1f7/i/m/img481_cr_3.jpg" });
            b2.Images.Add(new Image { Alt = "Чарлі і шоколадна фабрика", Url = "https://img.yakaboo.ua/media/catalog/product/cache/1/image/398x565/234c7c011ba026e66d29567e1be1d1f7/5/3/53225_28767120.jpg" });

            b3.Images.Add(new Image { Alt = "Гаррі Поттер i в’язень Азкабану", Url = "https://img.yakaboo.ua/media/catalog/product/cache/1/image/398x565/234c7c011ba026e66d29567e1be1d1f7/4/1/41815_65633137.jpg" });
            b4.Images.Add(new Image { Alt = "Гобіт, або Туди і звідти", Url = "https://img.yakaboo.ua/media/catalog/product/cache/1/image/398x565/234c7c011ba026e66d29567e1be1d1f7/2/1/21_3_43.jpg" });

            b5.Images.Add(new Image { Alt = "Відьмак. Останнє бажання", Url = "https://img.yakaboo.ua/media/catalog/product/cache/1/image/398x565/234c7c011ba026e66d29567e1be1d1f7/6/1/616607_front.jpg" });
            b6.Images.Add(new Image { Alt = "Мандрівний замок Хаула", Url = "https://img.yakaboo.ua/media/catalog/product/cache/1/image/398x565/234c7c011ba026e66d29567e1be1d1f7/i/m/img_0240_4.jpg" });
            b7.Images.Add(new Image { Alt = "Квіти для Елджернона", Url = "https://img.yakaboo.ua/media/catalog/product/cache/1/image/398x565/234c7c011ba026e66d29567e1be1d1f7/i/m/img_15840.jpg" });
            b8.Images.Add(new Image { Alt = "Мастер и Маргарита", Url = "https://img.yakaboo.ua/media/catalog/product/cache/1/image/398x565/234c7c011ba026e66d29567e1be1d1f7/i/m/img387_1_37.jpg" });
            b9.Images.Add(new Image { Alt = "Таємнича історія Біллі Міллігана", Url = "https://img.yakaboo.ua/media/catalog/product/cache/1/image/398x565/234c7c011ba026e66d29567e1be1d1f7/3/8/38656_59751.jpg" });
            b10.Images.Add(new Image { Alt = "Аеропорт", Url = "https://img.yakaboo.ua/media/catalog/product/cache/1/image/398x565/234c7c011ba026e66d29567e1be1d1f7/8/6/867305_cover_1.jpg" });



            g1 = new Genre { Name = "Фентезі", AddDate = DateTime.Now, Popularity = 0, Description = "Літературний жанр фантастичної літератури, дія якого відбувається у вигаданому світі, де чудеса і вигадка нашого світу є реальністю.", Books = new List<Book>(new[] { b1, b3, b4, b5 }) };
            g2 = new Genre { Name = "Пригоди", AddDate = DateTime.Now, Popularity = 0, Description = "Роман, сюжет якого насичений незвичайними подіями й характеризується їхнім несподіваним поворотом, великою динамікою розгортання.", Books = new List<Book>(new[] { b6, b2 }) };
            g4 = new Genre { Name = "Трилер", AddDate = DateTime.Now, Popularity = 0, Description = " жанр кіно та літератури, в яких специфічні засоби повинні викликати у глядачів або читачів почуття співпереживання пов'язане з емоціями тривожного очікування, невизначеності, хвилювання чи страху.", Books = new List<Book>(new[] { b9, b10 }) };
            g5 = new Genre { Name = "Класична проза", AddDate = DateTime.Now, Popularity = 0, Description = "мовлення не організоване ритмічно, не вритмоване; літературний твір або сукупність творів, написаних невіршованою мовою. Проза — один із двох основних типів літературної творчості.", Books = new List<Book>(new[] { b7, b8 }) };

            g1.Images.Add(new Image { Alt = "Фентезі_1", Url = "https://telegraf.com.ua/files/2019/01/book-0001.jpg" });
          
            g2.Images.Add(new Image { Alt = "Пригоди_1", Url = "https://www.anibox.org/_nw/81/96102578.jpg" });
            g2.Images.Add(new Image { Alt = "Пригоди_2", Url = "https://yokunev.com/wp/wp-content/uploads/2019/09/1426043334_96d5e0e82b.jpg" });
            g4.Images.Add(new Image { Alt = "Трилер_1", Url = "https://u.livelib.ru/reader/jump-jump/o/qe9pa80v/o-o.jpeg" });
            g4.Images.Add(new Image { Alt = "Трилер_2", Url = "https://cs10.pikabu.ru/post_img/big/2019/02/11/6/1549878580132197103.jpg" });
            g5.Images.Add(new Image { Alt = "Класична проза_1", Url = "https://kolobok.ua/i/81/48/60/814860/c3102f9c732eaa0694fde205c713bfcf-quality_70Xresize_crop_1Xallow_enlarge_0Xw_698Xh_465.jpg" });
            g5.Images.Add(new Image { Alt = "Класична проза_2", Url = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQcfz_UbWyp7Whd2_j7yNaHlTyx6Z4nYNIirVdYTf65kaxf2awy&usqp=CAU" });

           

            var a1 = new Author { AddDate = DateTime.Now, DateBirth = DateTime.Parse("1965-07-31"), FirstName = "Джоан", LastName = "Роулінг", Populatity = 0, Description = "Британська письменниця, сценаристка, кінопродюсерка, здебільшого відома як авторка серії романів про Гаррі Поттера. Її книги одержали світове визнання, виграли низку нагород і вийшли тиражем понад 400 мільйонів примірників. Септологія очолила список найбільш продаваних серій романів в історії та була екранізована в серії однойменних кінофільмів, у продюсуванні та створенні сценарію до яких доклалась і сама письменниця." };
            var a2 = new Author { AddDate = DateTime.Now, DateBirth = DateTime.Parse("1916-09-13"), FirstName = "Роальд", LastName = "Дал", Populatity = 0, Description = "Валлійський письменник норвезького походження, автор романів, повістей, новел, оповідань, написаних як для дорослих, так і для дітей, зокрема казково-фантастичних творів та творів у жанрі фантастики жахів. Лауреат численних премій, військовий герой. Його найвідомішими творами є: «Чарлі і шоколадна фабрика», «Джеймс і гігантський персик», «Матильда», «Відьми», «Докори» та «ВДВ (Великий Дружній Велетень)». За сюжетами його книжок знято культові кінофільми Willy Wonka & the Chocolate Factory у 1971 (рімейк «Чарлі і шоколадна фабрика» у 2005), та анімаційний Незрівнянний містер Фокс, «Ґремліни», та ще декілька." };
            var a3 = new Author { AddDate = DateTime.Now, DateBirth = DateTime.Parse("1892-01-03"), FirstName = "Джон", LastName = "Толкін", Populatity = 0, Description = "Англійський письменник, поет, філолог і професор, класик світової літератури ХХ ст. та один із фундаторів жанрового різновиду фантастики — високе фентезі. Найбільш відомий як автор «Гобіта», «Володаря перснів» та «Сильмариліона»." };
            var a4 = new Author { AddDate = DateTime.Now, DateBirth = DateTime.Parse("1948-06-21"), FirstName = "Анджей", LastName = "Сапковський", Populatity = 0, Description = "Польський письменник-фантаст і публіцист. Українською мовою твори Сапковського виходили у видавництвах «Клуб сімейного дозвілля» (серія «Відьмак»), Зелений пес («Трилогія гуситська») та у журналі «Всесвіт»." };
            var a5 = new Author { AddDate = DateTime.Now, DateBirth = DateTime.Parse("1934-08-16"), FirstName = "Діана Вінн", LastName = "Джонс", Populatity = 0, Description = "Британська письменниця, авторка фантастичних романів для дітей та дорослих. Найбільш відомі роботи — це серія книг про Крестомансі (англ. Chrestomanci) і роман «Мандрівний замок Хаула» (англ. Howl's Moving Castle), а також «Темний Володар Деркгольму» (англ. Dark Lord of Derkholm)." };
            var a6 = new Author { AddDate = DateTime.Now, DateBirth = DateTime.Parse("1927-08-09"), FirstName = "Деніел", LastName = "Кіз", Populatity = 0, Description = "Американський письменник. Насамперед відомий як автор науково-фантастичного роману «Квіти для Елджернона». 2001 року отримав звання «Заслуженого автора фантастики» від «Американського товариства письменників-фантастів»." };
            var a7 = new Author { AddDate = DateTime.Now, DateBirth = DateTime.Parse("1891-05-15"), FirstName = "Михайло", LastName = "Булгаков", Populatity = 0, Description = "Російський письменник, драматург, лібретист, лікар. Член Всеросійського союзу письменників (1923–1929) та спілки письменників СРСР (1934-1940). Серед найвизначніших книг Булгакова — романи «Майстер і Маргарита», «Біла гвардія» та «Дияволіада»." };
            var a8 = new Author { AddDate = DateTime.Now, DateBirth = DateTime.Parse("1920-04-05"), FirstName = "Артур", LastName = "Гейлі", Populatity = 0, Description = "Канадський прозаїк британського походження, який створив ряд бестселерів в жанрі виробничого роману." };

            a1.Books.Add(b1);
            a1.Books.Add(b3);
            a2.Books.Add(b2);
            a3.Books.Add(b4);
            a4.Books.Add(b5);
            a5.Books.Add(b6);
            a6.Books.Add(b7);
            a6.Books.Add(b9);
            a7.Books.Add(b8);
            a8.Books.Add(b10);

            a1.Images.Add(new Image { Alt = "J. K. Rowling img_1", Url = "https://upload.wikimedia.org/wikipedia/commons/f/fb/%C3%8Domha_J.K._Rowling.jpg" });
            a1.Images.Add(new Image { Alt = "J. K. Rowling img_2", Url = "https://vignette.wikia.nocookie.net/harrypotter/images/9/99/Joanne_Rowling_2018.jpg/revision/latest?cb=20181024170704&path-prefix=ru" });
            a2.Images.Add(new Image { Alt = "Roald Dahl img_1", Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/29/Roald_Dahl.jpg/300px-Roald_Dahl.jpg" });
            a2.Images.Add(new Image { Alt = "Roald Dahl img_2", Url = "https://www.ukrlib.com.ua/my/images/full/dal-roald.jpg" });
            a3.Images.Add(new Image { Alt = "John Ronald Reuel Tolkien img_1", Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b4/Tolkien_1916.jpg/274px-Tolkien_1916.jpg" });
            a3.Images.Add(new Image { Alt = "John Ronald Reuel Tolkien img_2", Url = "https://vignette.wikia.nocookie.net/lotr/images/9/94/UdA4ROZVgRc.jpg/revision/latest/top-crop/width/360/height/450?cb=20130103134652&path-prefix=ru" });
            a4.Images.Add(new Image { Alt = "Andrzej Sapkowski img_1", Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b8/Sapkowski.jpg/250px-Sapkowski.jpg" });
            a4.Images.Add(new Image { Alt = "Andrzej Sapkowski img_2", Url = "https://vokrug.tv/pic/person/6/e/4/2/6e420030951f75964ea1343601517d2e.jpg" });
            a5.Images.Add(new Image { Alt = "Diana Wynne Jones img_1", Url = "https://starylev.com.ua/files/styles/author_photo/public/author/djonse.jpg?itok=imzfTgp3" });
            a5.Images.Add(new Image { Alt = "Diana Wynne Jones img_2", Url = "https://www.ukrlib.com.ua/my/images/full/dzhons-diana-vinn_1.jpg" });
            a6.Images.Add(new Image { Alt = "Daniel Keyes img_1", Url = "https://upload.wikimedia.org/wikipedia/uk/e/ee/%D0%94%D0%B5%D0%BD%D1%96%D0%B5%D0%BB_%D0%9A%D1%96%D0%B7.jpg" });
            
            a7.Images.Add(new Image { Alt = "Михаил Афанасьевич Булгаков img_1", Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e0/Bulgakov1910s.jpg/435px-Bulgakov1910s.jpg" });
            
            a8.Images.Add(new Image { Alt = "Arthur Hailey img_1", Url = "https://upload.wikimedia.org/wikipedia/uk/thumb/e/ea/%D0%90%D1%80%D1%82%D1%83%D1%80_%D0%A5%D0%B5%D0%B9%D0%BB%D1%96.jpg/300px-%D0%90%D1%80%D1%82%D1%83%D1%80_%D0%A5%D0%B5%D0%B9%D0%BB%D1%96.jpg" });
            
            a1.Images.Add(new Image { Alt = "J. K. Rowling img_3", Url = "https://styleinsider.com.ua/wp-content/uploads/2017/04/jkrowling-e1446540738352.jpg" });
            a2.Images.Add(new Image { Alt = "Roald Dahl img_3", Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/01/Roald_Dahl_%281982%29.jpg/220px-Roald_Dahl_%281982%29.jpg" });
            a3.Images.Add(new Image { Alt = "John Ronald Reuel Tolkien img_3", Url = "https://soreal.ru/wp-content/uploads/2019/01/J.R.R-Tolkien-2.jpg" });
            a4.Images.Add(new Image { Alt = "Andrzej Sapkowski img_3", Url = "https://top-knig.ru/wp-content/uploads/2015/08/Sapkowskiy.jpg" });

            db.Authors.AddRange(new[] { a1, a2, a3, a4, a5, a6, a7, a8 });
            db.Genres.AddRange(new[] { g1, g2, g4, g5 });
            db.Books.AddRange(new[] { b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11 });

            db.SaveChanges();

        }

        
    }
}