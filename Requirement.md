# Molecule-Problem-2


1. Задача:
     Да се разработи структура от данни която представи молекула  като граф паметта. 
     Молекулният граф  се състои от: 

     * Атоми:  Състоят се от Тип атом и характеристики.  
 - Тип атом може да бъде една от следните абревиатури: [H,C ,N ,S ,P ,O ,Au ,Fe ,Co ,Pb]    (Подредени по нарастващо тегло)
 - Характеристики  
        Заряд:    възможен интервал от  [-6 -+6]
        Изотоп:   възможен интервал от  [0-1024] както и не дефиниран
        Координати  в тримерното пространство: 

     * Връзки:    Всяка връзка свързва два атома.                   
 - Връзките имат също характеристика тип на връзката с една от следните стойности:
[ Single, Double, Triple] 

2. Задача:
     Да се съставят следните алгоритми/функционалности работещи върху разработения молекулен граф. 
     
a. Добавяне/изтриване на атом към/от графа
Добавяне/изтриване на връзка към/от графа
Брой Точки: 2;  

b. Намиране на най-късия път между два произволно избрани атома.
Най-късия път е този който минава през най малко съседни атоми
(не се отчита разстоянието а броя атоми през които трябва да се премине).
При пътища с еднаква дължина по къс е патя съставен от по леки атоми.
Заряда и номера  на изотоп не се отчитат. При два еднакви пътища алгоритъма посочва и двата. 
Брой Точки: 10; 

c. Намиране на броя двусвързаните компоненти в графа. 
Двусвързан компонент се формира от най големия брой съседни циклични атоми:
Брой Точки: 8;
