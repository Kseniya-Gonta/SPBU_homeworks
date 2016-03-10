
#include <QDeclarativeImageProvider>
class ResourceImageProvider : public QDeclarativeImageProvider
{
public:
	ResourceImageProvider();
	~ResourceImageProvider();
	QImage requestImage(const QString& id, QSize* size, const QSize& requestedSize);
	QPixmap requestPixmap(const QString& id, QSize* size, const QSize& requestedSize);
};



