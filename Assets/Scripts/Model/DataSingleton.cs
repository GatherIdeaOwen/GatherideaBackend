using UnityEngine;
using System;
using System.Collections;

public abstract class DataSingleton<TSingleton> : DataSingleton where TSingleton : DataSingleton
{
	private static TSingleton _Inst;
	public static TSingleton Inst{
		get{
			if(_Inst == null) {
				_Inst = Activator.CreateInstance<TSingleton>();
				_Inst.init();
			}
			return _Inst;
		}
	}
}


public abstract class DataSingleton{
	
	private bool _hadInit;

	public void init(){
		if(_hadInit){
//			JSLogger.LogWarning("不能重複 Init");
			return;
		}
		_hadInit = true;
		onInit();
	}

	protected virtual void onInit(){ }
}