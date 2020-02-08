create database if not exists `testsinaviotomasyonu`;

create table if not exists `ders`
(`ders_id` int not null auto_increment primary key,
`ders_adi` varchar(45) not null
);

create table if not exists `kullanici`
(`kullanici_id` int not null primary key auto_increment,
`kullanici_ad` varchar(45) not null,
`kullanici_soyadi` varchar(45) not null,
`kullanici_sifre` varchar(45) not null,
`kullanici_sicilno` varchar(45) not null,
`kullanici_tipi` int not null
);

create table if not exists `ders_atama`
(`dersatama_id` int not null auto_increment primary key,
`ders_adi` varchar(45) not null,
`bolum_adi` varchar(45) not null,
`donem_adi` varchar(45) not null,
`kullanici_id` int not null,
constraint `fk_kullanici_id` foreign key (`kullanici_id`) references `kullanici`(`kullanici_id`)
);

create table if not exists `kazanim`
(`kazanim_id` int not null primary key auto_increment,
`kazanim_turu` varchar(45) not null,
`kazanim_turu_id` int not null,
`kazanim_adi` varchar(450) not null
);


create table if not exists `fakulte`
(`fakulte_id` int not null primary key auto_increment,
`fakulte_ad` varchar(45) not null
);



create table if not exists `bolum`
(`bolum_id` int not null primary key auto_increment,
`bolum_ad` varchar(45) not null,
`fakulte_adi` varchar(45) not null
);


create table if not exists `donem`
(`donem_id` int not null primary key auto_increment,
`donem_adi` varchar(45) not null,
`donem_durum` varchar(45) not null
);


create table if not exists `sinav`
(`sinav_id` int not null primary key auto_increment,
`sinav_xlsx` varchar(200) not null,
`dersatama_id` varchar(45) not null,
`sinav_turu` varchar(10) not null
);


use testsinaviotomasyonu;
insert into `kullanici`(`kullanici_ad`,`kullanici_soyadi`,`kullanici_sifre`,`kullanici_sicilno`,`kullanici_tipi`)
values("Yunus Emre","COSKUN","123","admin1","1") ;

DELIMITER //
CREATE PROCEDURE kullanici_sorgula()
BEGIN
SELECT * FROM kullanici;
END //
CREATE PROCEDURE fakulte_sorgula()
BEGIN
SELECT * FROM fakulte;
END //
CREATE PROCEDURE aktifdonemdersler_sorgula()
BEGIN
SELECT ders_atama.dersatama_id,ders_atama.ders_adi,ders_atama.bolum_adi,ders_atama.donem_adi,kullanici.kullanici_ad,kullanici.kullanici_soyadi FROM ders_atama
inner join kullanici on kullanici.kullanici_id=ders_atama.kullanici_id where donem_adi in (select donem_adi from donem where donem_durum="Aktif") group by(bolum_adi);
END //
CREATE PROCEDURE dersatama_sorgula()
BEGIN
SELECT ders_atama.dersatama_id,ders_atama.ders_adi,ders_atama.bolum_adi,ders_atama.donem_adi,kullanici.kullanici_ad,kullanici.kullanici_soyadi FROM ders_atama
inner join kullanici on kullanici.kullanici_id=ders_atama.kullanici_id;
END //
CREATE PROCEDURE kazanim_sorgula()
BEGIN
SELECT * FROM kazanim;
END //
CREATE PROCEDURE ders_sorgula()
BEGIN
SELECT * FROM ders;
END //
CREATE PROCEDURE donem_sorgula()
BEGIN
SELECT * FROM donem;
END //
CREATE PROCEDURE bolum_sorgula()
BEGIN
SELECT * FROM bolum;
END //
DELIMITER ;