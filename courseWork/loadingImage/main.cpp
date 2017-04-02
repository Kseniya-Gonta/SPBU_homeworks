#include "qtquick1applicationviewer.h"
#include <QApplication>
#include <QQmlApplicationEngine>
#include <QDeclarativeEngine>
#include <QDeclarativeImageProvider>
#include <QDebug>
#include <QDir>

class ColorImageProvider : public QDeclarativeImageProvider
{
public:
	ColorImageProvider()
		: QDeclarativeImageProvider(QDeclarativeImageProvider::Image)
	{
	}

	/*QPixmap requestPixmap(const QString &id, QSize *size, const QSize &requestedSize)
	{
		int width = 100;
		int height = 50;

		if (size)
			*size = QSize(width, height);
		QPixmap pixmap(requestedSize.width() > 0 ? requestedSize.width() : width,
					   requestedSize.height() > 0 ? requestedSize.height() : height);
		pixmap.fill(QColor(id).rgba());

		return pixmap;
	}*/
	QImage requestImage(const QString& id, QSize* size, const QSize& requestedSize)
	{
		qDebug() << id;
		QString way = QDir::currentPath() + "/../../../images/" + id;
		qDebug() <<  way;
		QImage image(way);
		QImage result;

		if (requestedSize.isValid()) {
			result = image.scaled(requestedSize, Qt::KeepAspectRatio);
		} else {
			result = image;
		}
		*size = result.size();
		return result;
	}
};

int main(int argc, char *argv[])
{
	QApplication app(argc, argv);
	QtQuick1ApplicationViewer viewer;
	QDeclarativeEngine *engine = viewer.engine();
	engine->addImageProvider(QLatin1String("colors"), new ColorImageProvider());
	viewer.addImportPath(QLatin1String("modules"));
	viewer.setOrientation(QtQuick1ApplicationViewer::ScreenOrientationAuto);
	viewer.setMainQmlFile(QLatin1String("qrc:/main.qml"));
	viewer.showExpanded();

	return app.exec();
}
