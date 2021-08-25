CREATE TABLE GESTOR (
CódigoG INTEGER PRIMARY KEY AUTOINCREMENT,
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
CódigoG INTEGER,
FOREIGN KEY (CódigoG) REFERENCES GESTOR(CódigoG)
);
CREATE TABLE CURSO(
CódigoC INTEGER PRIMARY KEY AUTOINCREMENT,
Nome VARCHAR,
Carga_Horária INTEGER
);
CREATE TABLE INSTRUTOR(
CódigoI INTEGER PRIMARY KEY AUTOINCREMENT,
Nome VARCHAR,
Telefone VARCHAR,
Departamento VARCHAR
);
CREATE TABLE TURMA(
CódigoT INTEGER PRIMARY KEY AUTOINCREMENT,
CódigoC INTEGER,
CódigoI INTEGER,
FOREIGN KEY (CódigoC) REFERENCES CURSO(CódigoC),
FOREIGN KEY (CódigoI) REFERENCES INSTRUTOR(CódigoI)
);
CREATE TABLE TURMA_HORÁRIOS(
Horários INTEGER PRIMARY KEY AUTOINCREMENT,
CódigoT INTEGER,
FOREIGN KEY (CódigoT) REFERENCES TURMA(CódigoT)
);
CREATE TABLE MATRÍCULA(
CódigoE INTEGER,
CódigoT INTEGER,
Frequência VARCHAR,
FOREIGN KEY (CódigoE) REFERENCES EMPREGADO(CódigoE),
FOREIGN KEY (CódigoT) REFERENCES TURMA(CódigoT)
);

INSERT INTO GESTOR(códigog,nome,departamento,cargo)
VALUES (1,"João","DECSI","Professor");
INSERT INTO GESTOR(códigog,nome,departamento,cargo)
VALUES (2,"André","DECSI","Coordenador");
INSERT INTO GESTOR(códigog,nome,departamento,cargo)
VALUES (3,"Nicole","DECSI","Administrador");
INSERT INTO EMPREGADO(códigoe,nome,endereço,cargo,códigog)
VALUES (1,"João","Rua das flores, 0","Professor",1);
INSERT INTO EMPREGADO(códigoe,nome,endereço,cargo,códigog)
VALUES (2,"André","Rua das flores, 0","Professor",2);
INSERT INTO CURSO(códigoc,nome,carga_horária)
VALUES (1,"Sistemas de Informação",2500);
INSERT INTO CURSO(códigoc,nome,carga_horária)
VALUES (2,"Engenharia de Computação",2500);
INSERT INTO INSTRUTOR(códigoi,nome,telefone,departamento)
VALUES (1,"Felipe","31999999","DECSI");
INSERT INTO INSTRUTOR(códigoi,nome,telefone,departamento)
VALUES (2,"Gabriel","31999999","DECSI");
INSERT INTO TURMA(códigot,códigoc,códigoi)
VALUES (1,1,1);
INSERT INTO TURMA(códigot,códigoc,códigoi)
VALUES (2,2,2);
INSERT INTO MATRÍCULA(códigoe,códigot,frequência)
VALUES (1,1,"10");
INSERT INTO MATRÍCULA(códigoe,códigot,frequência)
VALUES (2,1,"10");
INSERT into TURMA_HORÁRIOS(horários,códigot)
VALUES (1,1);
INSERT into TURMA_HORÁRIOS(horários,códigot)
VALUES (2,2);


