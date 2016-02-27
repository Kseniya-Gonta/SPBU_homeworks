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
			//QDomText text = elem.toText();
			Translator t;
			QString result = "";
			result += (QString("import QtQuick 2.0 \n").toLatin1());
			result += (QString("import CustomComponents 1.0 \n").toLatin1());
			result += (t.startTranslate(elem).toLatin1());
			qDebug() << result;
			//elem.childNodes().at(0).toText().setData(result);
			//elem.appendChild(QDomNode(result));
			//text.setData(result);
			//elem.setNodeValue(result);
			//elem.firstChild().setNodeValue(result);
			//elem.childNodes().at(1).setNodeValue(result);
			//doc.removeChild( doc.firstChildElement( ));
			//QDomElement newNodeTag = elem.createElement(result);
			//doc.parentNode().replaceChild(doc, newNodeTag);

			while (!elem.firstChild().isNull()) {
				elem.removeChild(elem.firstChild());
			}
			elem.setNodeValue(result);
			QDomText newNodeTag = elem.ownerDocument().createTextNode(result);
			elem.appendChild(newNodeTag);
			//QDomNode parent = doc.parentNode();
			//parent.firstChildElement("picture").firstChild().setNodeValue(result);
			//elem.firstChild()
			//doc.parentNode().removeChild( doc );
			//QDomNode zzxc;
			//zzxc.setNodeValue("asdf");
			//parent.appendChild( zzxc);
			//doc.setNodeValue("asdf");
			//doc.parentNode().setNodeValue("asdf");
			//qDebug() << doc.parentNode().toS
			//doc.replaceChild()
		}
		doc = doc.nextSibling();
	}
}

void parseGraphics(QDomNode doc)
{
	while (!doc.isNull())
	{
		//qDebug() << "nextcicle";
		QDomElement elem = doc.toElement();
		if(elem.tagName() == "graphics")
		{
			//qDebug() << "found graphics";
			parsePictures(elem.firstChild());
		}
		doc = doc.nextSibling();
	}
}

void parseNode(QDomNode doc)
{
	while (!doc.isNull())
	{
		//qDebug() << "nextcicle";
		QDomElement elem = doc.toElement();
		if(elem.tagName() == "node")
		{
			//qDebug() << "found node";
			parseGraphics(elem.firstChild());
		}
		doc = doc.nextSibling();
	}
}

void parseDiagram(QDomNode doc)
{
	while (!doc.isNull())
	{
		//qDebug() << "nextcicle";
		QDomElement elem = doc.toElement();
		if(elem.tagName() == "graphicTypes")
		{
			//qDebug() << "found graphicTypes";
			parseNode(elem.firstChild());
		}
		doc = doc.nextSibling();
	}
}

void parseMetamodel(QDomNode doc)
{
	while (!doc.isNull())
	{
		//qDebug() << "nextcicle";
		QDomElement elem = doc.toElement();
		if(elem.tagName() == "diagram")
		{
			//qDebug() << "found diagram";
			parseDiagram(elem.firstChild());
		}
		doc = doc.nextSibling();
	}
}

int main(int argc, char *argv[])
{
	QFile file("check.xml");
	if (!file.open(QIODevice::ReadWrite | QIODevice::Text))
		return 35;
	QDomDocument newdoc;
	if (!newdoc.setContent(&file)) {
		file.close();
		return 15;
	}
	file.close();

	QDomElement elem;
	QDomNode doc = newdoc.firstChild();
	while (!doc.isNull())
	{
		//qDebug() << "cicle";
		elem = doc.toElement();
		if(elem.tagName() == "metamodel")
		{
			//qDebug() << "found metamodel";
			parseMetamodel(elem.firstChild());
		}
		doc = doc.nextSibling();

	}


	qDebug() << newdoc.toString();

	return 0;
}
