#include "qtquick1applicationviewer.h"
#include <QApplication>
#include "imageprovider.h"

#include <QQmlEngine>
//#include <QQuickView>
int main(int argc, char *argv[])
{
    QApplication app(argc, argv);

	QtQuick1ApplicationViewer viewer;
    viewer.addImportPath(QLatin1String("modules"));
    viewer.setOrientation(QtQuick1ApplicationViewer::ScreenOrientationAuto);
    viewer.setMainQmlFile(QLatin1String("qrc:/main.qml"));
	viewer.showExpanded();
	//QQuickView view;
	QQmlEngine engine;
	engine->addImageProvider(QLatin1String("colors"), new ResourceImageProvider);
	return app.exec();
}
