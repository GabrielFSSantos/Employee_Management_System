CREATE TABLE GESTOR (
CódigoG INT PRIMARY KEY,
Nome VARCHAR,
Departamento VARCHAR,
Cargo VARCHAR
);
CREATE TABLE EMPREGADO(
CódigoE INTEGER PRIMARY KEY AUTOINCREMENT,
Nome VARCHAR,
Endereço VARCHAR,
Telefone VARCHAR,
Cargo VARCHAR,
CódigoG INT,
FOREIGN KEY (CódigoG) REFERENCES GESTOR(CódigoG)
);
CREATE TABLE CURSO(
CódigoC INT PRIMARY KEY,
Nome VARCHAR,
Carga_Horária INT
);
CREATE TABLE INSTRUTOR(
CódigoI INT PRIMARY KEY,
Nome VARCHAR,
Telefone VARCHAR,
Departamento VARCHAR
);
CREATE TABLE TURMA(
CódigoT INT PRIMARY KEY,
CódigoC INT,
CódigoI INT,
CódigoH INT,
FOREIGN KEY (CódigoC) REFERENCES CURSO(CódigoC),
FOREIGN KEY (CódigoI) REFERENCES INSTRUTOR(CódigoI),
FOREIGN KEY (CódigoH) REFERENCES HORÁRIOS(CódigoH)
);
CREATE TABLE HORÁRIOS(
CódigoH INT PRIMARY KEY,
Horário VARCHAR
);
CREATE TABLE MATRÍCULA(
CódigoE INT,
CódigoT INT,
Frequência VARCHAR,
FOREIGN KEY (CódigoE) REFERENCES EMPREGADO(CódigoE),
FOREIGN KEY (CódigoT) REFERENCES TURMA(CódigoT)
);

INSERT INTO GESTOR(códigog,nome,departamento,cargo)
VALUES (1,"Elton","DECSI","Professor");
INSERT INTO GESTOR(códigog,nome,departamento,cargo)
VALUES (2,"John","DECSI","Coordenador");
INSERT INTO GESTOR(códigog,nome,departamento,cargo)
VALUES (3,"Nicole","DECSI","Administrador");
INSERT INTO GESTOR(códigog,nome,departamento,cargo)
VALUES (4,"Daniela","DECSI","Administrador");
INSERT INTO EMPREGADO(códigoe,nome,endereço,cargo,códigog)
VALUES (1,"João","Rua das flores, 0","Professor",1);
INSERT INTO EMPREGADO(códigoe,nome,endereço,cargo,códigog)
VALUES (2,"André","Rua das flores, 0","Professor",2);
INSERT INTO CURSO(códigoc,nome,carga_horária)
VALUES (1,"NR10",250);
INSERT INTO CURSO(códigoc,nome,carga_horária)
VALUES (2,"Vendas",2500);
INSERT INTO INSTRUTOR(códigoi,nome,telefone,departamento)
VALUES (1,"Felipe","31999999","Vendas");
INSERT INTO INSTRUTOR(códigoi,nome,telefone,departamento)
VALUES (2,"Gabriel","31999999","Manutenção");
INSERT INTO TURMA(códigot,códigoc,códigoi,códigoh)
VALUES (1,1,1,1);
INSERT INTO TURMA(códigot,códigoc,códigoi,códigoh)
VALUES (2,2,2,2);
INSERT INTO MATRÍCULA(códigoe,códigot,frequência)
VALUES (1,1,"10");
INSERT INTO MATRÍCULA(códigoe,códigot,frequência)
VALUES (2,1,"10");
INSERT into HORÁRIOS(códigoh,horário)
VALUES (1,"13:00 - 15:10");
INSERT into HORÁRIOS(códigoh,horário)
VALUES (2,"15:30 - 17:00");


