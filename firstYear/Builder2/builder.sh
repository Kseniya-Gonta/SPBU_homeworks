#!/bin/bash

source config.sh 
function email_ok() {
	
	mail  -s "Build" $EMAIL_LOG <<< "It's ok!"
}

function email_fail() {
	mutt -a $1 -s "Build" -- $EMAIL_LOG <<< "Build failed!" 
}
function cloning() {
	rm -rf $FOLDER
	if [ !git clone $REPOSITORY &> clone.txt ]
		then 
			email_fail clone.txt
			exit 1
	fi
}


function checking() {
	
	
	while read p; do
		if [ ! -f $p ]
		then
			email_fail build.txt
			exit 1
		fi
	done < check.txt
	
	
}

cloning
checking
email_ok
