#include <QCoreApplication>
#include <QDomDocument>
#include <QApplication>
#include <QJsonDocument>
#include <QDebug>
#include <QFile>
#include <QXmlStreamReader>
#include <translator.h>

void parsePictures(QDomNode doc)
{
	while (!doc.isNull())
	{
		qDebug() << "nextcicle";
		QDomElement elem = doc.toElement();
		if(elem.tagName() == "picture")
		{
			qDebug() << "found picture";
			qDebug() << elem.tagName();
			Translator t;
			QFile files("test.qml");
			files.open(QIODevice::WriteOnly | QIODevice::Text);
			files.write(QString("import QtQuick 2.0 \n").toLatin1());
			files.write(QString("import CustomComponents 1.0 \n").toLatin1());
			files.write(t.startTranslate(elem).toLatin1());
		}
		doc = doc.nextSibling();
	}
}

void parseGraphics(QDomNode doc)
{
	while (!doc.isNull())
	{
		qDebug() << "nextcicle";
		QDomElement elem = doc.toElement();
		if(elem.tagName() == "graphics")
		{
			qDebug() << "found graphics";
			parsePictures(elem.firstChild());
		}
		doc = doc.nextSibling();
	}
}

void parseNode(QDomNode doc)
{
	while (!doc.isNull())
	{
		qDebug() << "nextcicle";
		QDomElement elem = doc.toElement();
		if(elem.tagName() == "node")
		{
			qDebug() << "found node";
			parseGraphics(elem.firstChild());
		}
		doc = doc.nextSibling();
	}
}

void parseDiagram(QDomNode doc)
{
	while (!doc.isNull())
	{
		qDebug() << "nextcicle";
		QDomElement elem = doc.toElement();
		if(elem.tagName() == "graphicTypes")
		{
			qDebug() << "found graphicTypes";
			parseNode(elem.firstChild());
		}
		doc = doc.nextSibling();
	}
}

void parseMetamodel(QDomNode doc)
{
	while (!doc.isNull())
	{
		qDebug() << "nextcicle";
		QDomElement elem = doc.toElement();
		if(elem.tagName() == "diagram")
		{
			qDebug() << "found diagram";
			parseDiagram(elem.firstChild());
		}
		doc = doc.nextSibling();
	}
}

int main(int argc, char *argv[])
{
	QFile file("robotsMetamodel.xml");
	if (!file.open(QIODevice::ReadOnly | QIODevice::Text))
		return 35;
	QDomDocument newdoc;
	if (!newdoc.setContent(&file)) {
		file.close();
		return 15;
	}

	QDomElement elem;
	QString result = "+++++";
	QDomNode doc = newdoc.firstChild();
	while (!doc.isNull())
	{
		qDebug() << "cicle";
		elem = doc.toElement();
		if(elem.tagName() == "metamodel")
		{
			qDebug() << "found metamodel";
			parseMetamodel(elem.firstChild());
		}
		doc = doc.nextSibling();

	}
	return 0;
}
