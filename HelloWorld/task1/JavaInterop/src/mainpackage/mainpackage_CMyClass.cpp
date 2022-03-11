#include"mainpackage_CMyClass.h"

jint Java_mainpackage_CMyClass_sum (JNIEnv*, jobject, jint a, jint b) {
	return a + b;
}